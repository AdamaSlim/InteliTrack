import api from '../api/axios';

export interface Product {
  id: number;
  name: string;
  barcode: string;
  categoryId: number;
  supplierId: number;
  unitPrice: number;
  minimumStockLevel: number;
  isActive: boolean;
}

export interface CreateProductPayload {
  name: string;
  barcode: string;
  categoryId: number;
  supplierId: number;
  unitPrice: number;
  minimumStockLevel: number;
}

export const productService = {
  getAll: async (): Promise<Product[]> => {
    const response = await api.get('/products');
    return response.data;
  },

  getById: async (id: number): Promise<Product> => {
    const response = await api.get(`/products/${id}`);
    return response.data;
  },

  create: async (payload: CreateProductPayload): Promise<Product> => {
    const response = await api.post('/products', payload);
    return response.data;
  },

  update: async (id: number, payload: Partial<CreateProductPayload>): Promise<Product> => {
    const response = await api.put(`/products/${id}`, payload);
    return response.data;
  },

  delete: async (id: number): Promise<void> => {
    await api.delete(`/products/${id}`);
  },
};
