import api from '../api/axios';

export const TransferStatus = {
  Pending: 0,
  InTransit: 1,
  Completed: 2,
  Cancelled: 3,
} as const;

export type TransferStatus = (typeof TransferStatus)[keyof typeof TransferStatus];

export interface TransferItem {
  id?: number;
  productId: number;
  productName?: string;
  quantity: number;
}

export interface Transfer {
  id: number;
  sourceStoreId: number;
  sourceStoreName?: string;
  destinationStoreId: number;
  destinationStoreName?: string;
  requestedByEmployeeId: number;
  createdAt: string;
  deliveredAt?: string;
  completedAt?: string;
  status: TransferStatus;
  items: TransferItem[];
}

export interface CreateTransferPayload {
  sourceStoreId: number;
  destinationStoreId: number;
  requestedByEmployeeId: number;
  items: { productId: number; quantity: number }[];
}

export interface TransferResult {
  success: boolean;
  message: string;
  transferId?: number;
}

export const transferService = {
  getAll: async (): Promise<Transfer[]> => {
    const response = await api.get('/transfers');
    return response.data;
  },

  getById: async (id: number): Promise<Transfer> => {
    const response = await api.get(`/transfers/${id}`);
    return response.data;
  },

  create: async (payload: CreateTransferPayload): Promise<TransferResult> => {
    const response = await api.post('/transfer/create', payload);
    return response.data;
  },

  startTransfer: async (transferId: number, employeeId: number): Promise<TransferResult> => {
    const response = await api.post(`/transfer/${transferId}/start?employeeId=${employeeId}`);
    return response.data;
  },

  completeTransfer: async (transferId: number, employeeId: number): Promise<TransferResult> => {
    const response = await api.post(`/transfer/${transferId}/complete?employeeId=${employeeId}`);
    return response.data;
  },

  cancelTransfer: async (transferId: number, employeeId: number): Promise<TransferResult> => {
    const response = await api.post(`/transfer/${transferId}/cancel?employeeId=${employeeId}`);
    return response.data;
  },
};
