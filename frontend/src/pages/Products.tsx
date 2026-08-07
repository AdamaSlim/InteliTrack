import React, { useEffect, useState } from 'react';
import { useOutletContext } from 'react-router-dom';
import { Plus, Package, Edit, Trash2, Tag, Barcode as BarcodeIcon } from 'lucide-react';
import { DataTable } from '../components/DataTable';
import type { Column } from '../components/DataTable';
import { productService } from '../services/productService';
import type { Product, CreateProductPayload } from '../services/productService';

export const Products: React.FC = () => {
  const { globalSearch } = useOutletContext<{ globalSearch: string }>();
  const [products, setProducts] = useState<Product[]>([]);
  const [loading, setLoading] = useState(true);
  const [isModalOpen, setIsModalOpen] = useState(false);

  // Form state
  const [formData, setFormData] = useState<CreateProductPayload>({
    name: '',
    barcode: '',
    categoryId: 1,
    supplierId: 1,
    unitPrice: 0,
    minimumStockLevel: 5,
  });

  const loadProducts = async () => {
    try {
      setLoading(true);
      const data = await productService.getAll();
      setProducts(data || []);
    } catch (err) {
      console.error('Error fetching products:', err);
      // Fallback demo data if backend is offline or empty
      setProducts([
        { id: 1, name: 'Clavier Mécanique RGB', barcode: 'PROD-1001', categoryId: 1, supplierId: 1, unitPrice: 89.99, minimumStockLevel: 10, isActive: true },
        { id: 2, name: 'Souris Sans Fil Ergonomique', barcode: 'PROD-1002', categoryId: 1, supplierId: 2, unitPrice: 45.0, minimumStockLevel: 15, isActive: true },
        { id: 3, name: 'Écran 27" 4K UHD', barcode: 'PROD-1003', categoryId: 2, supplierId: 1, unitPrice: 349.99, minimumStockLevel: 5, isActive: true },
      ]);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    loadProducts();
  }, []);

  const handleCreateSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      await productService.create(formData);
      setIsModalOpen(false);
      setFormData({
        name: '',
        barcode: '',
        categoryId: 1,
        supplierId: 1,
        unitPrice: 0,
        minimumStockLevel: 5,
      });
      loadProducts();
    } catch (err) {
      alert("Erreur lors de la création du produit. Vérifiez le backend.");
    }
  };

  const handleDelete = async (id: number) => {
    if (confirm('Voulez-vous vraiment supprimer ce produit ?')) {
      try {
        await productService.delete(id);
        loadProducts();
      } catch (err) {
        alert('Erreur lors de la suppression.');
      }
    }
  };

  const columns: Column<Product>[] = [
    {
      key: 'name',
      header: 'Nom du Produit',
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
            <div style={{ fontWeight: 600, color: '#ffffff' }}>{item.name}</div>
            <div style={{ fontSize: '0.75rem', color: 'var(--text-muted)' }}>ID: #{item.id}</div>
          </div>
        </div>
      ),
    },
    {
      key: 'barcode',
      header: 'Code-Barres / SKU',
      sortable: true,
      render: (item) => (
        <div style={{ display: 'flex', alignItems: 'center', gap: '0.35rem', fontFamily: 'monospace' }}>
          <BarcodeIcon size={14} color="var(--text-dark)" />
          <span>{item.barcode || 'N/A'}</span>
        </div>
      ),
    },
    {
      key: 'unitPrice',
      header: 'Prix Unitaire',
      sortable: true,
      render: (item) => (
        <span style={{ fontWeight: 600, color: '#34d399' }}>
          {Number(item.unitPrice).toFixed(2)} €
        </span>
      ),
    },
    {
      key: 'minimumStockLevel',
      header: 'Seuil Minimum',
      sortable: true,
      render: (item) => (
        <span className="badge badge-amber">
          <Tag size={12} /> {item.minimumStockLevel} unités
        </span>
      ),
    },
    {
      key: 'actions',
      header: 'Actions',
      render: (item) => (
        <div style={{ display: 'flex', gap: '0.5rem' }}>
          <button
            className="btn btn-secondary"
            style={{ padding: '0.35rem 0.5rem' }}
            title="Modifier"
          >
            <Edit size={14} />
          </button>
          <button
            className="btn btn-danger"
            style={{ padding: '0.35rem 0.5rem' }}
            onClick={() => handleDelete(item.id)}
            title="Supprimer"
          >
            <Trash2 size={14} />
          </button>
        </div>
      ),
    },
  ];

  return (
    <div className="animate-fade-in" style={{ display: 'flex', flexDirection: 'column', gap: '1.5rem' }}>
      {/* Header bar */}
      <div style={{ display: 'flex', alignItems: 'center', justifyContent: 'space-between' }}>
        <div>
          <h2 style={{ fontSize: '1.5rem', fontWeight: 700, color: '#ffffff', margin: 0 }}>
            Catalogue Produits
          </h2>
          <p style={{ color: 'var(--text-muted)', fontSize: '0.875rem' }}>
            Gérez vos références articles, codes-barres et tarifs.
          </p>
        </div>
        <button className="btn btn-primary" onClick={() => setIsModalOpen(true)}>
          <Plus size={16} /> Ajouter un produit
        </button>
      </div>

      {/* Data Table */}
      <DataTable columns={columns} data={products} searchQuery={globalSearch} loading={loading} />

      {/* Create Product Modal */}
      {isModalOpen && (
        <div className="modal-overlay" onClick={() => setIsModalOpen(false)}>
          <div className="modal-content" onClick={(e) => e.stopPropagation()}>
            <h3 style={{ fontSize: '1.25rem', fontWeight: 700, color: '#ffffff', marginBottom: '1.25rem' }}>
              Ajouter un Nouveau Produit
            </h3>
            <form onSubmit={handleCreateSubmit} style={{ display: 'flex', flexDirection: 'column', gap: '1rem' }}>
              <div>
                <label style={{ fontSize: '0.8rem', color: 'var(--text-muted)', display: 'block', marginBottom: '0.25rem' }}>
                  Nom du Produit
                </label>
                <input
                  type="text"
                  required
                  className="input-field"
                  value={formData.name}
                  onChange={(e) => setFormData({ ...formData, name: e.target.value })}
                />
              </div>

              <div style={{ display: 'grid', gridTemplateColumns: '1fr 1fr', gap: '1rem' }}>
                <div>
                  <label style={{ fontSize: '0.8rem', color: 'var(--text-muted)', display: 'block', marginBottom: '0.25rem' }}>
                    Code-Barres
                  </label>
                  <input
                    type="text"
                    required
                    className="input-field"
                    value={formData.barcode}
                    onChange={(e) => setFormData({ ...formData, barcode: e.target.value })}
                  />
                </div>
                <div>
                  <label style={{ fontSize: '0.8rem', color: 'var(--text-muted)', display: 'block', marginBottom: '0.25rem' }}>
                    Prix Unitaire (€)
                  </label>
                  <input
                    type="number"
                    step="0.01"
                    required
                    className="input-field"
                    value={formData.unitPrice}
                    onChange={(e) => setFormData({ ...formData, unitPrice: parseFloat(e.target.value) || 0 })}
                  />
                </div>
              </div>

              <div style={{ display: 'grid', gridTemplateColumns: '1fr 1fr', gap: '1rem' }}>
                <div>
                  <label style={{ fontSize: '0.8rem', color: 'var(--text-muted)', display: 'block', marginBottom: '0.25rem' }}>
                    Catégorie ID
                  </label>
                  <input
                    type="number"
                    required
                    className="input-field"
                    value={formData.categoryId}
                    onChange={(e) => setFormData({ ...formData, categoryId: parseInt(e.target.value) || 1 })}
                  />
                </div>
                <div>
                  <label style={{ fontSize: '0.8rem', color: 'var(--text-muted)', display: 'block', marginBottom: '0.25rem' }}>
                    Seuil Stock Min.
                  </label>
                  <input
                    type="number"
                    required
                    className="input-field"
                    value={formData.minimumStockLevel}
                    onChange={(e) => setFormData({ ...formData, minimumStockLevel: parseInt(e.target.value) || 0 })}
                  />
                </div>
              </div>

              <div style={{ display: 'flex', justifyContent: 'flex-end', gap: '0.75rem', marginTop: '1rem' }}>
                <button type="button" className="btn btn-secondary" onClick={() => setIsModalOpen(false)}>
                  Annuler
                </button>
                <button type="submit" className="btn btn-primary">
                  Enregistrer
                </button>
              </div>
            </form>
          </div>
        </div>
      )}
    </div>
  );
};
