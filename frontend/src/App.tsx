import { BrowserRouter, Routes, Route } from 'react-router-dom';
import { MainLayout } from './layouts/MainLayout';
import { Dashboard } from './pages/Dashboard';
import { Products } from './pages/Products';
import { Stores } from './pages/Stores';
import { Stocks } from './pages/Stocks';
import { Transfers } from './pages/Transfers';

export function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<MainLayout />}>
          <Route index element={<Dashboard />} />
          <Route path="products" element={<Products />} />
          <Route path="stores" element={<Stores />} />
          <Route path="stocks" element={<Stocks />} />
          <Route path="transfers" element={<Transfers />} />
        </Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
