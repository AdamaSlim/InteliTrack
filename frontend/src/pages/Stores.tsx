import React, { useEffect, useState } from 'react';
import { useOutletContext } from 'react-router-dom';
import { Store as StoreIcon, MapPin, Phone, Plus, CheckCircle, Trash2 } from 'lucide-react';
import { DataTable } from '../components/DataTable';
import type { Column } from '../components/DataTable';
import { storeService } from '../services/storeService';
import type { Store, CreateStorePayload } from '../services/storeService';

export const Stores: React.FC = () => {
  const { globalSearch } = useOutletContext<{ globalSearch: string }>();
  const [stores, setStores] = useState<Store[]>([]);
  const [loading, setLoading] = useState(true);
  const [isModalOpen, setIsModalOpen] = useState(false);

  const [formData, setFormData] = useState<CreateStorePayload>({
    name: '',
    city: '',
    address: '',
    phone: '',
  });

  const loadStores = async () => {
    try {
      setLoading(true);
      const data = await storeService.getAll();
      setStores(data || []);
    } catch (err) {
      console.error('Error fetching stores:', err);
      // Fallback demo stores
      setStores([
        { id: 1, name: 'Magasin Central Paris', city: 'Paris', address: '12 Rue de Rivoli', phone: '+33 1 40 20 50 00', isActive: true },
        { id: 2, name: 'Entrepôt Lyon Sud', city: 'Lyon', address: '45 Avenue Jean Jaurès', phone: '+33 4 72 00 11 22', isActive: true },
        { id: 3, name: 'Boutique Marseille Vieux-Port', city: 'Marseille', address: '8 Quai du Port', phone: '+33 4 91 00 33 44', isActive: true },
      ]);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    loadStores();
  }, []);

  const handleCreateSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      await storeService.create(formData);
      setIsModalOpen(false);
      setFormData({ name: '', city: '', address: '', phone: '' });
      loadStores();
    } catch (err) {
      alert('Erreur lors de la création du magasin.');
    }
  };

  const handleDelete = async (id: number) => {
    if (confirm('Supprimer ce magasin ?')) {
      try {
        await storeService.delete(id);
        loadStores();
      } catch (err) {
        alert('Erreur lors de la suppression.');
      }
    }
  };

  const columns: Column<Store>[] = [
    {
      key: 'name',
      header: 'Nom du Magasin',
      sortable: true,
      render: (item) => (
        <div style={{ display: 'flex', alignItems: 'center', gap: '0.75rem' }}>
          <div
            style={{
              padding: '0.4rem',
              borderRadius: 'var(--radius-sm)',
              backgroundColor: 'rgba(16, 185, 129, 0.15)',
              color: '#34d399',
            }}
          >
            <StoreIcon size={16} />
          </div>
          <div>
            <div style={{ fontWeight: 600, color: '#ffffff' }}>{item.name}</div>
            <div style={{ fontSize: '0.75rem', color: 'var(--text-muted)' }}>ID: #{item.id}</div>
          </div>
        </div>
      ),
    },
    {
      key: 'city',
      header: 'Ville',
      sortable: true,
      render: (item) => (
        <div style={{ display: 'flex', alignItems: 'center', gap: '0.35rem' }}>
          <MapPin size={14} color="var(--text-dark)" />
          <span>{item.city}</span>
        </div>
      ),
    },
    {
      key: 'address',
      header: 'Adresse',
      render: (item) => <span style={{ color: 'var(--text-muted)' }}>{item.address}</span>,
    },
    {
      key: 'phone',
      header: 'Téléphone',
      render: (item) => (
        <div style={{ display: 'flex', alignItems: 'center', gap: '0.35rem' }}>
          <Phone size={14} color="var(--text-dark)" />
          <span>{item.phone || 'N/A'}</span>
        </div>
      ),
    },
    {
      key: 'isActive',
      header: 'Statut',
      render: (item) => (
        <span className={`badge ${item.isActive ? 'badge-emerald' : 'badge-rose'}`}>
          <CheckCircle size={12} /> {item.isActive ? 'Actif' : 'Inactif'}
        </span>
      ),
    },
    {
      key: 'actions',
      header: 'Actions',
      render: (item) => (
        <button
          className="btn btn-danger"
          style={{ padding: '0.35rem 0.5rem' }}
          onClick={() => handleDelete(item.id)}
          title="Supprimer"
        >
          <Trash2 size={14} />
        </button>
      ),
    },
  ];

  return (
    <div className="animate-fade-in" style={{ display: 'flex', flexDirection: 'column', gap: '2rem' }}>
      {/* Page Header */}
      <div style={{ display: 'flex', alignItems: 'center', justifyContent: 'space-between' }}>
        <div>
          <h2 style={{ fontSize: '1.5rem', fontWeight: 700, color: '#ffffff', margin: 0 }}>
            Gestion des Magasins & Entrepôts
          </h2>
          <p style={{ color: 'var(--text-muted)', fontSize: '0.875rem' }}>
            Consultez les sites physiques et leurs emplacements.
          </p>
        </div>
        <button className="btn btn-primary" onClick={() => setIsModalOpen(true)}>
          <Plus size={16} /> Ajouter un magasin
        </button>
      </div>

      {/* Cards Grid Overview */}
      <div style={{ display: 'grid', gridTemplateColumns: 'repeat(auto-fit, minmax(280px, 1fr))', gap: '1.25rem' }}>
        {stores.map((s) => (
          <div key={s.id} className="glass-card" style={{ padding: '1.25rem', display: 'flex', flexDirection: 'column', gap: '0.75rem' }}>
            <div style={{ display: 'flex', alignItems: 'center', justifyContent: 'space-between' }}>
              <span className="badge badge-emerald">Opérationnel</span>
              <span style={{ fontSize: '0.75rem', color: 'var(--text-dark)' }}>ID #{s.id}</span>
            </div>
            <h3 style={{ fontSize: '1.1rem', fontWeight: 700, color: '#ffffff', margin: 0 }}>{s.name}</h3>
            <div style={{ display: 'flex', flexDirection: 'column', gap: '0.35rem', fontSize: '0.85rem', color: 'var(--text-muted)' }}>
              <div style={{ display: 'flex', alignItems: 'center', gap: '0.5rem' }}>
                <MapPin size={14} color="#818cf8" /> {s.city} ({s.address})
              </div>
              <div style={{ display: 'flex', alignItems: 'center', gap: '0.5rem' }}>
                <Phone size={14} color="#34d399" /> {s.phone}
              </div>
            </div>
          </div>
        ))}
      </div>

      {/* Full Store Data Table */}
      <DataTable columns={columns} data={stores} searchQuery={globalSearch} loading={loading} />

      {/* Create Modal */}
      {isModalOpen && (
        <div className="modal-overlay" onClick={() => setIsModalOpen(false)}>
          <div className="modal-content" onClick={(e) => e.stopPropagation()}>
            <h3 style={{ fontSize: '1.25rem', fontWeight: 700, color: '#ffffff', marginBottom: '1.25rem' }}>
              Nouveau Magasin
            </h3>
            <form onSubmit={handleCreateSubmit} style={{ display: 'flex', flexDirection: 'column', gap: '1rem' }}>
              <div>
                <label style={{ fontSize: '0.8rem', color: 'var(--text-muted)', display: 'block', marginBottom: '0.25rem' }}>
                  Nom du Magasin / Entrepôt
                </label>
                <input
                  type="text"
                  required
                  className="input-field"
                  value={formData.name}
                  onChange={(e) => setFormData({ ...formData, name: e.target.value })}
                />
              </div>

              <div>
                <label style={{ fontSize: '0.8rem', color: 'var(--text-muted)', display: 'block', marginBottom: '0.25rem' }}>
                  Ville
                </label>
                <input
                  type="text"
                  required
                  className="input-field"
                  value={formData.city}
                  onChange={(e) => setFormData({ ...formData, city: e.target.value })}
                />
              </div>

              <div>
                <label style={{ fontSize: '0.8rem', color: 'var(--text-muted)', display: 'block', marginBottom: '0.25rem' }}>
                  Adresse complète
                </label>
                <input
                  type="text"
                  required
                  className="input-field"
                  value={formData.address}
                  onChange={(e) => setFormData({ ...formData, address: e.target.value })}
                />
              </div>

              <div>
                <label style={{ fontSize: '0.8rem', color: 'var(--text-muted)', display: 'block', marginBottom: '0.25rem' }}>
                  Numéro de Téléphone
                </label>
                <input
                  type="text"
                  required
                  className="input-field"
                  value={formData.phone}
                  onChange={(e) => setFormData({ ...formData, phone: e.target.value })}
                />
              </div>

              <div style={{ display: 'flex', justifyContent: 'flex-end', gap: '0.75rem', marginTop: '1rem' }}>
                <button type="button" className="btn btn-secondary" onClick={() => setIsModalOpen(false)}>
                  Annuler
                </button>
                <button type="submit" className="btn btn-primary">
                  Créer le Magasin
                </button>
              </div>
            </form>
          </div>
        </div>
      )}
    </div>
  );
};
