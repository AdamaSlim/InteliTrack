import React, { useState } from 'react';
import { Outlet, useLocation } from 'react-router-dom';
import { Sidebar } from '../components/Sidebar';
import { Navbar } from '../components/Navbar';

export const MainLayout: React.FC = () => {
  const location = useLocation();
  const [globalSearch, setGlobalSearch] = useState('');

  // Map route pathname to page title
  const getPageTitle = (pathname: string) => {
    switch (pathname) {
      case '/':
        return 'Tableau de bord';
      case '/products':
        return 'Catalogue Produits';
      case '/stores':
        return 'Gestion des Magasins';
      case '/stocks':
        return 'Suivi des Stocks';
      case '/transfers':
        return 'Transferts Inter-Magasins';
      default:
        return 'InteliTrack';
    }
  };

  return (
    <div style={{ display: 'flex', width: '100%', minHeight: '100vh', backgroundColor: 'var(--bg-main)' }}>
      {/* Sidebar Navigation */}
      <Sidebar />

      {/* Main Content Area */}
      <div style={{ flex: 1, display: 'flex', flexDirection: 'column', minWidth: 0 }}>
        <Navbar title={getPageTitle(location.pathname)} onSearchChange={setGlobalSearch} />
        
        <main style={{ flex: 1, padding: '2rem', maxWidth: '1600px', width: '100%', margin: '0 auto' }}>
          <Outlet context={{ globalSearch }} />
        </main>
      </div>
    </div>
  );
};
