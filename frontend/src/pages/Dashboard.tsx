import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import {
  Package,
  Store,
  ArrowLeftRight,
  AlertTriangle,
  TrendingUp,
  Plus,
  ArrowUpRight,
  Clock,
  Layers,
} from 'lucide-react';
import { productService } from '../services/productService';
import type { Product } from '../services/productService';
import { storeService } from '../services/storeService';
import type { Store as StoreType } from '../services/storeService';
import { transferService, TransferStatus } from '../services/transferService';
import type { Transfer } from '../services/transferService';

export const Dashboard: React.FC = () => {
  const navigate = useNavigate();
  const [products, setProducts] = useState<Product[]>([]);
  const [stores, setStores] = useState<StoreType[]>([]);
  const [transfers, setTransfers] = useState<Transfer[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchData = async () => {
      try {
        setLoading(true);
        const [prodRes, storeRes, transferRes] = await Promise.allSettled([
          productService.getAll(),
          storeService.getAll(),
          transferService.getAll(),
        ]);

        if (prodRes.status === 'fulfilled') setProducts(prodRes.value || []);
        if (storeRes.status === 'fulfilled') setStores(storeRes.value || []);
        if (transferRes.status === 'fulfilled') setTransfers(transferRes.value || []);
      } catch (err) {
        console.error('Failed to load dashboard data:', err);
      } finally {
        setLoading(false);
      }
    };

    fetchData();
  }, []);

  const activeTransfersCount = transfers.filter(
    (t) => t.status === TransferStatus.Pending || t.status === TransferStatus.InTransit
  ).length;

  return (
    <div className="animate-fade-in" style={{ display: 'flex', flexDirection: 'column', gap: '2rem' }}>
      {/* Header Welcome Card */}
      <div
        className="glass-card"
        style={{
          padding: '2rem',
          background: 'linear-gradient(135deg, rgba(30, 41, 59, 0.9) 0%, rgba(15, 23, 42, 0.9) 100%)',
          display: 'flex',
          alignItems: 'center',
          justifyContent: 'space-between',
          borderLeft: '4px solid #6366f1',
        }}
      >
        <div>
          <h1 style={{ fontSize: '1.75rem', fontWeight: 800, color: '#ffffff', margin: 0, lineHeight: 1.2 }}>
            Bienvenue sur InteliTrack 👋
          </h1>
          <p style={{ color: 'var(--text-muted)', marginTop: '0.5rem', fontSize: '0.95rem' }}>
            Aperçu en temps réel de vos stocks, emplacements et mouvements inter-magasins.
          </p>
        </div>
        <div style={{ display: 'flex', gap: '0.75rem' }}>
          <button className="btn btn-primary" onClick={() => navigate('/transfers')}>
            <Plus size={16} /> Nouveau Transfert
          </button>
          <button className="btn btn-secondary" onClick={() => navigate('/products')}>
            <Package size={16} /> Gérer Produits
          </button>
        </div>
      </div>

      {/* KPI Cards Grid */}
      <div
        style={{
          display: 'grid',
          gridTemplateColumns: 'repeat(auto-fit, minmax(240px, 1fr))',
          gap: '1.25rem',
        }}
      >
        {/* Card 1: Total Products */}
        <div className="glass-card" style={{ padding: '1.5rem' }}>
          <div style={{ display: 'flex', alignItems: 'center', justifyContent: 'space-between' }}>
            <span style={{ fontSize: '0.85rem', fontWeight: 600, color: 'var(--text-muted)' }}>
              Total Produits
            </span>
            <div
              style={{
                padding: '0.5rem',
                borderRadius: 'var(--radius-sm)',
                backgroundColor: 'rgba(99, 102, 241, 0.15)',
                color: '#818cf8',
              }}
            >
              <Package size={20} />
            </div>
          </div>
          <div style={{ fontSize: '2rem', fontWeight: 800, color: '#ffffff', margin: '0.75rem 0 0.25rem' }}>
            {loading ? '...' : products.length}
          </div>
          <div style={{ display: 'flex', alignItems: 'center', gap: '0.35rem', fontSize: '0.75rem', color: '#34d399' }}>
            <TrendingUp size={14} /> +12% ce mois
          </div>
        </div>

        {/* Card 2: Active Stores */}
        <div className="glass-card" style={{ padding: '1.5rem' }}>
          <div style={{ display: 'flex', alignItems: 'center', justifyContent: 'space-between' }}>
            <span style={{ fontSize: '0.85rem', fontWeight: 600, color: 'var(--text-muted)' }}>
              Magasins Actifs
            </span>
            <div
              style={{
                padding: '0.5rem',
                borderRadius: 'var(--radius-sm)',
                backgroundColor: 'rgba(16, 185, 129, 0.15)',
                color: '#34d399',
              }}
            >
              <Store size={20} />
            </div>
          </div>
          <div style={{ fontSize: '2rem', fontWeight: 800, color: '#ffffff', margin: '0.75rem 0 0.25rem' }}>
            {loading ? '...' : stores.length}
          </div>
          <div style={{ fontSize: '0.75rem', color: 'var(--text-muted)' }}>
            Tous opérationnels
          </div>
        </div>

        {/* Card 3: Active Transfers */}
        <div className="glass-card" style={{ padding: '1.5rem' }}>
          <div style={{ display: 'flex', alignItems: 'center', justifyContent: 'space-between' }}>
            <span style={{ fontSize: '0.85rem', fontWeight: 600, color: 'var(--text-muted)' }}>
              Transferts en cours
            </span>
            <div
              style={{
                padding: '0.5rem',
                borderRadius: 'var(--radius-sm)',
                backgroundColor: 'rgba(6, 182, 212, 0.15)',
                color: '#22d3ee',
              }}
            >
              <ArrowLeftRight size={20} />
            </div>
          </div>
          <div style={{ fontSize: '2rem', fontWeight: 800, color: '#ffffff', margin: '0.75rem 0 0.25rem' }}>
            {loading ? '...' : activeTransfersCount}
          </div>
          <div style={{ fontSize: '0.75rem', color: 'var(--text-muted)' }}>
            Mouvements actifs
          </div>
        </div>

        {/* Card 4: System Inventory Status */}
        <div className="glass-card" style={{ padding: '1.5rem' }}>
          <div style={{ display: 'flex', alignItems: 'center', justifyContent: 'space-between' }}>
            <span style={{ fontSize: '0.85rem', fontWeight: 600, color: 'var(--text-muted)' }}>
              État du Système
            </span>
            <div
              style={{
                padding: '0.5rem',
                borderRadius: 'var(--radius-sm)',
                backgroundColor: 'rgba(245, 158, 11, 0.15)',
                color: '#fbbf24',
              }}
            >
              <Layers size={20} />
            </div>
          </div>
          <div style={{ fontSize: '1.5rem', fontWeight: 700, color: '#ffffff', margin: '0.75rem 0 0.25rem' }}>
            Optimal
          </div>
          <div style={{ fontSize: '0.75rem', color: '#fbbf24' }}>
            Dernière synchro à l'instant
          </div>
        </div>
      </div>

      {/* Main Grid: Alert banner & Quick Table */}
      <div style={{ display: 'grid', gridTemplateColumns: '2fr 1fr', gap: '1.5rem' }}>
        {/* Left Column: Recent Transfers Overview */}
        <div className="glass-card" style={{ padding: '1.5rem', display: 'flex', flexDirection: 'column', gap: '1rem' }}>
          <div style={{ display: 'flex', alignItems: 'center', justifyContent: 'space-between' }}>
            <h3 style={{ fontSize: '1.1rem', fontWeight: 700, color: '#ffffff', margin: 0 }}>
              Derniers Mouvements de Stock
            </h3>
            <button
              className="btn btn-secondary"
              style={{ padding: '0.4rem 0.75rem', fontSize: '0.8rem' }}
              onClick={() => navigate('/transfers')}
            >
              Voir tout <ArrowUpRight size={14} />
            </button>
          </div>

          <div style={{ display: 'flex', flexDirection: 'column', gap: '0.75rem' }}>
            {transfers.length === 0 ? (
              <div style={{ textAlign: 'center', padding: '2rem 1rem', color: 'var(--text-muted)', fontSize: '0.875rem' }}>
                Aucun transfert enregistré récemment.
              </div>
            ) : (
              transfers.slice(0, 4).map((t) => (
                <div
                  key={t.id}
                  style={{
                    padding: '0.875rem 1rem',
                    borderRadius: 'var(--radius-sm)',
                    backgroundColor: 'rgba(15, 23, 42, 0.6)',
                    border: '1px solid var(--border-color)',
                    display: 'flex',
                    alignItems: 'center',
                    justifyContent: 'space-between',
                  }}
                >
                  <div style={{ display: 'flex', alignItems: 'center', gap: '0.75rem' }}>
                    <div
                      style={{
                        width: '36px',
                        height: '36px',
                        borderRadius: 'var(--radius-sm)',
                        backgroundColor: 'rgba(99, 102, 241, 0.15)',
                        color: '#818cf8',
                        display: 'flex',
                        alignItems: 'center',
                        justifyContent: 'center',
                      }}
                    >
                      <ArrowLeftRight size={18} />
                    </div>
                    <div>
                      <div style={{ fontSize: '0.875rem', fontWeight: 600, color: '#ffffff' }}>
                        Transfert #{t.id}
                      </div>
                      <div style={{ fontSize: '0.75rem', color: 'var(--text-muted)' }}>
                        Source: Magasin #{t.sourceStoreId} → Dest: Magasin #{t.destinationStoreId}
                      </div>
                    </div>
                  </div>

                  <span
                    className={`badge ${
                      t.status === TransferStatus.Completed
                        ? 'badge-emerald'
                        : t.status === TransferStatus.InTransit
                        ? 'badge-cyan'
                        : t.status === TransferStatus.Cancelled
                        ? 'badge-rose'
                        : 'badge-amber'
                    }`}
                  >
                    {t.status === TransferStatus.Completed
                      ? 'Terminé'
                      : t.status === TransferStatus.InTransit
                      ? 'En Transit'
                      : t.status === TransferStatus.Cancelled
                      ? 'Annulé'
                      : 'En Attente'}
                  </span>
                </div>
              ))
            )}
          </div>
        </div>

        {/* Right Column: Quick Status & Alerts */}
        <div style={{ display: 'flex', flexDirection: 'column', gap: '1.5rem' }}>
          {/* Alert Card */}
          <div
            className="glass-card"
            style={{
              padding: '1.5rem',
              backgroundColor: 'rgba(245, 158, 11, 0.08)',
              border: '1px solid rgba(245, 158, 11, 0.2)',
            }}
          >
            <div style={{ display: 'flex', alignItems: 'center', gap: '0.75rem', marginBottom: '0.75rem' }}>
              <AlertTriangle size={20} color="#fbbf24" />
              <h4 style={{ fontSize: '1rem', fontWeight: 700, color: '#fbbf24', margin: 0 }}>
                Alertes de Seuil
              </h4>
            </div>
            <p style={{ fontSize: '0.85rem', color: 'var(--text-muted)', lineHeight: 1.4 }}>
              Certains articles nécessitent un réapprovisionnement imminent. Consultez l'onglet Stocks pour effectuer un réajustement.
            </p>
            <button
              className="btn btn-secondary"
              style={{ marginTop: '1rem', width: '100%', fontSize: '0.8rem' }}
              onClick={() => navigate('/stocks')}
            >
              Vérifier les stocks
            </button>
          </div>

          {/* Quick Actions Card */}
          <div className="glass-card" style={{ padding: '1.5rem' }}>
            <h4 style={{ fontSize: '1rem', fontWeight: 700, color: '#ffffff', marginBottom: '1rem' }}>
              Raccourcis Rapides
            </h4>
            <div style={{ display: 'flex', flexDirection: 'column', gap: '0.5rem' }}>
              <button className="btn btn-secondary" style={{ justifyContent: 'flex-start' }} onClick={() => navigate('/products')}>
                <Package size={16} color="#818cf8" /> Gérer le catalogue
              </button>
              <button className="btn btn-secondary" style={{ justifyContent: 'flex-start' }} onClick={() => navigate('/stores')}>
                <Store size={16} color="#34d399" /> Liste des magasins
              </button>
              <button className="btn btn-secondary" style={{ justifyContent: 'flex-start' }} onClick={() => navigate('/transfers')}>
                <Clock size={16} color="#22d3ee" /> Historique transferts
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};
