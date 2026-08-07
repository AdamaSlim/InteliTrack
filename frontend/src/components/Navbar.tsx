import React from 'react';
import { Search, Bell, User, Sparkles } from 'lucide-react';

interface NavbarProps {
  title?: string;
  onSearchChange?: (term: string) => void;
}

export const Navbar: React.FC<NavbarProps> = ({ title = 'Tableau de bord', onSearchChange }) => {
  return (
    <header
      style={{
        height: '70px',
        backgroundColor: 'var(--bg-navbar)',
        backdropFilter: 'blur(12px)',
        borderBottom: '1px solid var(--border-color)',
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'space-between',
        padding: '0 2rem',
        position: 'sticky',
        top: 0,
        zIndex: 40,
      }}
    >
      {/* Title & Page context */}
      <div style={{ display: 'flex', alignItems: 'center', gap: '0.75rem' }}>
        <h2 style={{ fontSize: '1.25rem', fontWeight: 700, color: '#ffffff', margin: 0 }}>
          {title}
        </h2>
        <span className="badge badge-indigo">
          <Sparkles size={12} />
          Realtime
        </span>
      </div>

      {/* Right Controls: Search bar & User info */}
      <div style={{ display: 'flex', alignItems: 'center', gap: '1.25rem' }}>
        {/* Search input */}
        <div style={{ position: 'relative', width: '260px' }}>
          <Search
            size={16}
            color="var(--text-muted)"
            style={{ position: 'absolute', left: '12px', top: '50%', transform: 'translateY(-50%)' }}
          />
          <input
            type="text"
            placeholder="Rechercher..."
            className="input-field"
            style={{ paddingLeft: '36px' }}
            onChange={(e) => onSearchChange?.(e.target.value)}
          />
        </div>

        {/* Notification Bell */}
        <button
          className="btn-secondary"
          style={{
            width: '40px',
            height: '40px',
            borderRadius: 'var(--radius-sm)',
            padding: 0,
            position: 'relative',
          }}
          aria-label="Notifications"
        >
          <Bell size={18} color="var(--text-muted)" />
          <span
            style={{
              position: 'absolute',
              top: '8px',
              right: '8px',
              width: '8px',
              height: '8px',
              borderRadius: '50%',
              backgroundColor: '#f43f5e',
            }}
          />
        </button>

        {/* User Profile */}
        <div
          style={{
            display: 'flex',
            alignItems: 'center',
            gap: '0.75rem',
            paddingLeft: '0.75rem',
            borderLeft: '1px solid var(--border-color)',
          }}
        >
          <div
            style={{
              width: '36px',
              height: '36px',
              borderRadius: '50%',
              backgroundColor: 'rgba(99, 102, 241, 0.2)',
              border: '1px solid rgba(99, 102, 241, 0.4)',
              display: 'flex',
              alignItems: 'center',
              justifyContent: 'center',
              color: '#818cf8',
            }}
          >
            <User size={18} />
          </div>
          <div style={{ display: 'flex', flexDirection: 'column' }}>
            <span style={{ fontSize: '0.85rem', fontWeight: 600, color: '#ffffff', lineHeight: 1.2 }}>
              Adama Traoré
            </span>
            <span style={{ fontSize: '0.75rem', color: 'var(--text-muted)' }}>
              Gestionnaire Stock
            </span>
          </div>
        </div>
      </div>
    </header>
  );
};
