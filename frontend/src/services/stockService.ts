import api from '../api/axios';

export interface StockItem {
  id: number;
  productId: number;
  productName?: string;
  storeId: number;
  storeName?: string;
  shelfId?: number;
  quantity: number;
  minimumLevel: number;
  lastUpdated?: string;
}

export interface AddStockPayload {
  stockId: number;
  quantity: number;
  employeeId: number;
  reason?: string;
}

export interface RemoveStockPayload {
  stockId: number;
  quantity: number;
  employeeId: number;
  reason?: string;
}

export interface StockOperationResult {
  success: boolean;
  message: string;
  newQuantity: number;
}

export const stockService = {
  getAll: async (): Promise<StockItem[]> => {
    const response = await api.get('/stocks');
    return response.data;
  },

  getByStore: async (storeId: number): Promise<StockItem[]> => {
    const response = await api.get(`/stocks/store/${storeId}`);
    return response.data;
  },

  addStock: async (payload: AddStockPayload): Promise<StockOperationResult> => {
    const response = await api.post('/stock/add', payload);
    return response.data;
  },

  removeStock: async (payload: RemoveStockPayload): Promise<StockOperationResult> => {
    const response = await api.post('/stock/remove', payload);
    return response.data;
  },
};
