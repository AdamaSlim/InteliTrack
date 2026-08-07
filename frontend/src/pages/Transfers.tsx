import React, { useEffect, useState } from 'react';
import { useOutletContext } from 'react-router-dom';
import { ArrowLeftRight, Plus, Play, CheckCircle, XCircle, Clock } from 'lucide-react';
import { DataTable } from '../components/DataTable';
import type { Column } from '../components/DataTable';
import { transferService, TransferStatus } from '../services/transferService';
import type { Transfer, CreateTransferPayload } from '../services/transferService';
import { storeService } from '../services/storeService';
import type { Store } from '../services/storeService';
import { productService } from '../services/productService';
import type { Product } from '../services/productService';

export const Transfers: React.FC = () => {
  const { globalSearch } = useOutletContext<{ globalSearch: string }>();
  const [transfers, setTransfers] = useState<Transfer[]>([]);
  const [stores, setStores] = useState<Store[]>([]);
  const [products, setProducts] = useState<Product[]>([]);
  const [loading, setLoading] = useState(true);
  const [isModalOpen, setIsModalOpen] = useState(false);

  // Form State
  const [sourceStoreId, setSourceStoreId] = useState(1);
  const [destStoreId, setDestStoreId] = useState(2);
  const [selectedProductId, setSelectedProductId] = useState(1);
  const [transferQty, setTransferQty] = useState(10);

  const loadData = async () => {
    try {
      setLoading(true);
      const [transRes, storeRes, prodRes] = await Promise.allSettled([
        transferService.getAll(),
        storeService.getAll(),
        productService.getAll(),
      ]);

      if (transRes.status === 'fulfilled') setTransfers(transRes.value || []);
      if (storeRes.status === 'fulfilled') setStores(storeRes.value || []);
      if (prodRes.status === 'fulfilled') setProducts(prodRes.value || []);
    } catch (err) {
      console.error('Error fetching transfers data:', err);
      // Fallback demo transfers
      setTransfers([
        {
          id: 101,
          sourceStoreId: 1,
          sourceStoreName: 'Central Paris',
          destinationStoreId: 2,
          destinationStoreName: 'Lyon Sud',
          requestedByEmployeeId: 1,
          createdAt: new Date().toISOString(),
          status: TransferStatus.InTransit,
          items: [{ productId: 1, productName: 'Clavier Mécanique RGB', quantity: 15 }],
        },
        {
          id: 102,
          sourceStoreId: 2,
          sourceStoreName: 'Lyon Sud',
          destinationStoreId: 1,
          destinationStoreName: 'Central Paris',
          requestedByEmployeeId: 1,
          createdAt: new Date().toISOString(),
          status: TransferStatus.Completed,
          items: [{ productId: 2, productName: 'Souris Sans Fil Ergonomique', quantity: 20 }],
        },
      ]);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    loadData();
  }, []);

  const handleCreateTransfer = async (e: React.FormEvent) => {
    e.preventDefault();
    if (sourceStoreId === destStoreId) {
      alert('Le magasin d\'origine et de destination doivent être différents.');
      return;
    }

    try {
      const payload: CreateTransferPayload = {
        sourceStoreId,
        destinationStoreId: destStoreId,
        requestedByEmployeeId: 1,
        items: [{ productId: selectedProductId, quantity: transferQty }],
      };
      await transferService.create(payload);
      setIsModalOpen(false);
      loadData();
    } catch (err) {
      alert('Erreur lors de la création du transfert.');
    }
  };

  const handleStart = async (id: number) => {
    try {
      await transferService.startTransfer(id, 1);
      loadData();
    } catch (err) {
      alert('Erreur lors du démarrage du transfert.');
    }
  };

  const handleComplete = async (id: number) => {
    try {
      await transferService.completeTransfer(id, 1);
      loadData();
    } catch (err) {
      alert('Erreur lors de la validation du transfert.');
    }
  };

  const handleCancel = async (id: number) => {
    if (confirm('Annuler ce transfert ?')) {
      try {
        await transferService.cancelTransfer(id, 1);
        loadData();
      } catch (err) {
        alert('Erreur lors de l\'annulation.');
      }
    }
  };

  const columns: Column<Transfer>[] = [
    {
      key: 'id',
      header: 'Transfert #',
      sortable: true,
      render: (item) => (
        <div style={{ display: 'flex', alignItems: 'center', gap: '0.5rem', fontWeight: 700, color: '#ffffff' }}>
          <ArrowLeftRight size={16} color="#818cf8" />
          <span>#{item.id}</span>
        </div>
      ),
    },
    {
      key: 'route',
      header: 'Trajet (Source → Destination)',
      render: (item) => (
        <div style={{ fontSize: '0.85rem' }}>
          <span style={{ color: '#ffffff', fontWeight: 600 }}>
            {item.sourceStoreName || `Magasin #${item.sourceStoreId}`}
          </span>
          <span style={{ margin: '0 0.5rem', color: 'var(--text-dark)' }}>➔</span>
          <span style={{ color: '#34d399', fontWeight: 600 }}>
            {item.destinationStoreName || `Magasin #${item.destinationStoreId}`}
          </span>
        </div>
      ),
    },
    {
      key: 'items',
      header: 'Articles Transférés',
      render: (item) => (
        <div style={{ fontSize: '0.8rem', color: 'var(--text-muted)' }}>
          {item.items && item.items.length > 0 ? (
            item.items.map((it, idx) => (
              <div key={idx}>
                {it.productName || `Produit #${it.productId}`}: <strong style={{ color: '#ffffff' }}>{it.quantity} units</strong>
              </div>
            ))
          ) : (
            <span>Articles non renseignés</span>
          )}
        </div>
      ),
    },
    {
      key: 'status',
      header: 'Statut',
      sortable: true,
      render: (item) => {
        switch (item.status) {
          case TransferStatus.Completed:
            return (
              <span className="badge badge-emerald">
                <CheckCircle size={12} /> Terminé
              </span>
            );
          case TransferStatus.InTransit:
            return (
              <span className="badge badge-cyan">
                <Play size={12} /> En Transit
              </span>
            );
          case TransferStatus.Cancelled:
            return (
              <span className="badge badge-rose">
                <XCircle size={12} /> Annulé
              </span>
            );
          default:
            return (
              <span className="badge badge-amber">
                <Clock size={12} /> En Attente
              </span>
            );
        }
      },
    },
    {
      key: 'actions',
      header: 'Changement de Statut',
      render: (item) => (
        <div style={{ display: 'flex', gap: '0.4rem' }}>
          {item.status === TransferStatus.Pending && (
            <button
              className="btn btn-secondary"
              style={{ padding: '0.35rem 0.5rem', fontSize: '0.75rem' }}
              onClick={() => handleStart(item.id)}
            >
              <Play size={12} /> Démarrer
            </button>
          )}
          {item.status === TransferStatus.InTransit && (
            <button
              className="btn btn-success"
              style={{ padding: '0.35rem 0.5rem', fontSize: '0.75rem' }}
              onClick={() => handleComplete(item.id)}
            >
              <CheckCircle size={12} /> Réceptionner
            </button>
          )}
          {item.status !== TransferStatus.Completed && item.status !== TransferStatus.Cancelled && (
            <button
              className="btn btn-danger"
              style={{ padding: '0.35rem 0.5rem', fontSize: '0.75rem' }}
              onClick={() => handleCancel(item.id)}
            >
              <XCircle size={12} /> Annuler
            </button>
          )}
        </div>
      ),
    },
  ];

  return (
    <div className="animate-fade-in" style={{ display: 'flex', flexDirection: 'column', gap: '1.5rem' }}>
      {/* Header */}
      <div style={{ display: 'flex', alignItems: 'center', justifyContent: 'space-between' }}>
        <div>
          <h2 style={{ fontSize: '1.5rem', fontWeight: 700, color: '#ffffff', margin: 0 }}>
            Transferts Inter-Magasins
          </h2>
          <p style={{ color: 'var(--text-muted)', fontSize: '0.875rem' }}>
            Supervisez et validez les mouvements de marchandise d'un site à un autre.
          </p>
        </div>
        <button className="btn btn-primary" onClick={() => setIsModalOpen(true)}>
          <Plus size={16} /> Créer un transfert
        </button>
      </div>

      {/* Main Table */}
      <DataTable columns={columns} data={transfers} searchQuery={globalSearch} loading={loading} />

      {/* Create Modal */}
      {isModalOpen && (
        <div className="modal-overlay" onClick={() => setIsModalOpen(false)}>
          <div className="modal-content" onClick={(e) => e.stopPropagation()}>
            <h3 style={{ fontSize: '1.25rem', fontWeight: 700, color: '#ffffff', marginBottom: '1.25rem' }}>
              Créer un Transfert de Stock
            </h3>

            <form onSubmit={handleCreateTransfer} style={{ display: 'flex', flexDirection: 'column', gap: '1rem' }}>
              <div>
                <label style={{ fontSize: '0.8rem', color: 'var(--text-muted)', display: 'block', marginBottom: '0.25rem' }}>
                  Magasin d'Origine (Source)
                </label>
                <select
                  className="input-field"
                  value={sourceStoreId}
                  onChange={(e) => setSourceStoreId(parseInt(e.target.value))}
                >
                  {stores.length > 0 ? (
                    stores.map((s) => (
                      <option key={s.id} value={s.id}>
                        {s.name} ({s.city})
                      </option>
                    ))
                  ) : (
                    <>
                      <option value={1}>Central Paris (ID: 1)</option>
                      <option value={2}>Lyon Sud (ID: 2)</option>
                    </>
                  )}
                </select>
              </div>

              <div>
                <label style={{ fontSize: '0.8rem', color: 'var(--text-muted)', display: 'block', marginBottom: '0.25rem' }}>
                  Magasin de Destination
                </label>
                <select
                  className="input-field"
                  value={destStoreId}
                  onChange={(e) => setDestStoreId(parseInt(e.target.value))}
                >
                  {stores.length > 0 ? (
                    stores.map((s) => (
                      <option key={s.id} value={s.id}>
                        {s.name} ({s.city})
                      </option>
                    ))
                  ) : (
                    <>
                      <option value={2}>Lyon Sud (ID: 2)</option>
                      <option value={1}>Central Paris (ID: 1)</option>
                    </>
                  )}
                </select>
              </div>

              <div style={{ display: 'grid', gridTemplateColumns: '2fr 1fr', gap: '1rem' }}>
                <div>
                  <label style={{ fontSize: '0.8rem', color: 'var(--text-muted)', display: 'block', marginBottom: '0.25rem' }}>
                    Produit à transférer
                  </label>
                  <select
                    className="input-field"
                    value={selectedProductId}
                    onChange={(e) => setSelectedProductId(parseInt(e.target.value))}
                  >
                    {products.length > 0 ? (
                      products.map((p) => (
                        <option key={p.id} value={p.id}>
                          {p.name} ({p.barcode})
                        </option>
                      ))
                    ) : (
                      <>
                        <option value={1}>Clavier Mécanique RGB</option>
                        <option value={2}>Souris Sans Fil</option>
                      </>
                    )}
                  </select>
                </div>

                <div>
                  <label style={{ fontSize: '0.8rem', color: 'var(--text-muted)', display: 'block', marginBottom: '0.25rem' }}>
                    Quantité
                  </label>
                  <input
                    type="number"
                    min="1"
                    className="input-field"
                    value={transferQty}
                    onChange={(e) => setTransferQty(parseInt(e.target.value) || 1)}
                  />
                </div>
              </div>

              <div style={{ display: 'flex', justifyContent: 'flex-end', gap: '0.75rem', marginTop: '1rem' }}>
                <button type="button" className="btn btn-secondary" onClick={() => setIsModalOpen(false)}>
                  Annuler
                </button>
                <button type="submit" className="btn btn-primary">
                  Initier le Transfert
                </button>
              </div>
            </form>
          </div>
        </div>
      )}
    </div>
  );
};
