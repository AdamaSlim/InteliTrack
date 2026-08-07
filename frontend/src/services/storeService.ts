import api from '../api/axios';

export interface Store {
  id: number;
  name: string;
  city: string;
  address: string;
  phone: string;
  isActive: boolean;
}

export interface CreateStorePayload {
  name: string;
  city: string;
  address: string;
  phone: string;
}

export const storeService = {
  getAll: async (): Promise<Store[]> => {
    const response = await api.get('/stores');
    return response.data;
  },

  getById: async (id: number): Promise<Store> => {
    const response = await api.get(`/stores/${id}`);
    return response.data;
  },

  create: async (payload: CreateStorePayload): Promise<Store> => {
    const response = await api.post('/stores', payload);
    return response.data;
  },

  update: async (id: number, payload: Partial<CreateStorePayload>): Promise<Store> => {
    const response = await api.put(`/stores/${id}`, payload);
    return response.data;
  },

  delete: async (id: number): Promise<void> => {
    await api.delete(`/stores/${id}`);
  },
};
