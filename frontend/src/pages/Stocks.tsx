import React, { useEffect, useState } from 'react';
import { useOutletContext } from 'react-router-dom';
import { PlusCircle, MinusCircle, AlertTriangle, CheckCircle, Store, Package } from 'lucide-react';
import { DataTable } from '../components/DataTable';
import type { Column } from '../components/DataTable';
import { stockService } from '../services/stockService';
import type { StockItem } from '../services/stockService';

export const Stocks: React.FC = () => {
  const { globalSearch } = useOutletContext<{ globalSearch: string }>();
  const [stocks, setStocks] = useState<StockItem[]>([]);
  const [loading, setLoading] = useState(true);

  // Modal State for Stock adjustment
  const [activeModal, setActiveModal] = useState<'add' | 'remove' | null>(null);
  const [selectedStock, setSelectedStock] = useState<StockItem | null>(null);
  const [quantityInput, setQuantityInput] = useState(1);
  const [reasonInput, setReasonInput] = useState('');

  const loadStocks = async () => {
    try {
      setLoading(true);
      const data = await stockService.getAll();
      setStocks(data || []);
    } catch (err) {
      console.error('Error fetching stock data:', err);
      // Fallback demo stock items
      setStocks([
        { id: 1, productId: 1, productName: 'Clavier Mécanique RGB', storeId: 1, storeName: 'Central Paris', quantity: 45, minimumLevel: 10 },
        { id: 2, productId: 2, productName: 'Souris Sans Fil Ergonomique', storeId: 1, storeName: 'Central Paris', quantity: 4, minimumLevel: 15 },
        { id: 3, productId: 3, productName: 'Écran 27" 4K UHD', storeId: 2, storeName: 'Lyon Sud', quantity: 18, minimumLevel: 5 },
      ]);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    loadStocks();
  }, []);

  const handleStockActionSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!selectedStock) return;

    try {
      if (activeModal === 'add') {
        await stockService.addStock({
          stockId: selectedStock.id,
          quantity: quantityInput,
          employeeId: 1,
          reason: reasonInput,
        });
      } else if (activeModal === 'remove') {
        await stockService.removeStock({
          stockId: selectedStock.id,
          quantity: quantityInput,
          employeeId: 1,
          reason: reasonInput,
        });
      }
      setActiveModal(null);
      setSelectedStock(null);
      setQuantityInput(1);
      setReasonInput('');
      loadStocks();
    } catch (err) {
      alert("Erreur lors de l'opération sur le stock.");
    }
  };

  const openAdjustmentModal = (stock: StockItem, type: 'add' | 'remove') => {
    setSelectedStock(stock);
    setActiveModal(type);
    setQuantityInput(1);
    setReasonInput('');
  };

  const columns: Column<StockItem>[] = [
    {
      key: 'productName',
      header: 'Produit',
      sortable: true,
      render: (item) => (
        <div style={{ display: 'flex', alignItems: 'center', gap: '0.75rem' }}>
          <div
            style={{
              padding: '0.4rem',
              borderRadius: 'var(--radius-sm)',
              backgroundColor: 'rgba(99, 102, 241, 0.15)',
              color: '#818cf8',
            }}
          >
            <Package size={16} />
          </div>
          <div>
            <div style={{ fontWeight: 600, color: '#ffffff' }}>
              {item.productName || `Produit #${item.productId}`}
            </div>
            <div style={{ fontSize: '0.75rem', color: 'var(--text-muted)' }}>Stock ID: #{item.id}</div>
          </div>
        </div>
      ),
    },
    {
      key: 'storeName',
      header: 'Magasin / Emplacement',
      sortable: true,
      render: (item) => (
        <div style={{ display: 'flex', alignItems: 'center', gap: '0.35rem' }}>
          <Store size={14} color="#34d399" />
          <span>{item.storeName || `Magasin #${item.storeId}`}</span>
        </div>
      ),
    },
    {
      key: 'quantity',
      header: 'Quantité en Stock',
      sortable: true,
      render: (item) => {
        const isLow = item.quantity <= item.minimumLevel;
        return (
          <div style={{ display: 'flex', alignItems: 'center', gap: '0.5rem' }}>
            <span style={{ fontSize: '1rem', fontWeight: 700, color: isLow ? '#f87171' : '#ffffff' }}>
              {item.quantity}
            </span>
            <span className={`badge ${isLow ? 'badge-rose' : 'badge-emerald'}`}>
              {isLow ? <AlertTriangle size={12} /> : <CheckCircle size={12} />}
              {isLow ? 'Stock Bas' : 'Disponible'}
            </span>
          </div>
        );
      },
    },
    {
      key: 'minimumLevel',
      header: 'Seuil Min.',
      render: (item) => <span style={{ color: 'var(--text-muted)' }}>{item.minimumLevel} unités</span>,
    },
    {
      key: 'actions',
      header: 'Ajustement',
      render: (item) => (
        <div style={{ display: 'flex', gap: '0.5rem' }}>
          <button
            className="btn btn-success"
            style={{ padding: '0.35rem 0.6rem', fontSize: '0.75rem' }}
            onClick={() => openAdjustmentModal(item, 'add')}
          >
            <PlusCircle size={14} /> Entrée
          </button>
          <button
            className="btn btn-danger"
            style={{ padding: '0.35rem 0.6rem', fontSize: '0.75rem' }}
            onClick={() => openAdjustmentModal(item, 'remove')}
          >
            <MinusCircle size={14} /> Sortie
          </button>
        </div>
      ),
    },
  ];

  return (
    <div className="animate-fade-in" style={{ display: 'flex', flexDirection: 'column', gap: '1.5rem' }}>
      {/* Header */}
      <div>
        <h2 style={{ fontSize: '1.5rem', fontWeight: 700, color: '#ffffff', margin: 0 }}>
          Suivi des Inventaires & Stocks
        </h2>
        <p style={{ color: 'var(--text-muted)', fontSize: '0.875rem' }}>
          Visualisez les niveaux de stock par magasin et effectuez des entrées/sorties en temps réel.
        </p>
      </div>

      {/* Main Stock Table */}
      <DataTable columns={columns} data={stocks} searchQuery={globalSearch} loading={loading} />

      {/* Stock Adjustment Modal */}
      {activeModal && selectedStock && (
        <div className="modal-overlay" onClick={() => setActiveModal(null)}>
          <div className="modal-content" onClick={(e) => e.stopPropagation()}>
            <h3 style={{ fontSize: '1.25rem', fontWeight: 700, color: '#ffffff', marginBottom: '0.5rem' }}>
              {activeModal === 'add' ? 'Ajouter du Stock (Entrée)' : 'Retirer du Stock (Sortie)'}
            </h3>
            <p style={{ fontSize: '0.85rem', color: 'var(--text-muted)', marginBottom: '1.25rem' }}>
              Produit: <strong style={{ color: '#ffffff' }}>{selectedStock.productName || `#${selectedStock.productId}`}</strong> (Stock actuel: {selectedStock.quantity})
            </p>

            <form onSubmit={handleStockActionSubmit} style={{ display: 'flex', flexDirection: 'column', gap: '1rem' }}>
              <div>
                <label style={{ fontSize: '0.8rem', color: 'var(--text-muted)', display: 'block', marginBottom: '0.25rem' }}>
                  Quantité à {activeModal === 'add' ? 'ajouter' : 'retirer'}
                </label>
                <input
                  type="number"
                  min="1"
                  required
                  className="input-field"
                  value={quantityInput}
                  onChange={(e) => setQuantityInput(parseInt(e.target.value) || 1)}
                />
              </div>

              <div>
                <label style={{ fontSize: '0.8rem', color: 'var(--text-muted)', display: 'block', marginBottom: '0.25rem' }}>
                  Motif / Remarque (Optionnel)
                </label>
                <input
                  type="text"
                  placeholder="Ex: Réapprovisionnement fournisseur, Casse, etc."
                  className="input-field"
                  value={reasonInput}
                  onChange={(e) => setReasonInput(e.target.value)}
                />
              </div>

              <div style={{ display: 'flex', justifyContent: 'flex-end', gap: '0.75rem', marginTop: '1rem' }}>
                <button type="button" className="btn btn-secondary" onClick={() => setActiveModal(null)}>
                  Annuler
                </button>
                <button
                  type="submit"
                  className={activeModal === 'add' ? 'btn btn-success' : 'btn btn-danger'}
                >
                  Valider {activeModal === 'add' ? 'l\'entrée' : 'la sortie'}
                </button>
              </div>
            </form>
          </div>
        </div>
      )}
    </div>
  );
};
