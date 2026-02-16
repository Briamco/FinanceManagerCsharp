import type { Category, GeneralReport, Spend } from "../types";

export const apiService = {
  getCategory: async (): Promise<Category[]> => {
    const res = await fetch('/api/category')
    return await res.json()
  },

  addCategory: async (cat: Omit<Category, 'id'>): Promise<void> => {
    const res = await fetch('/api/Category', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(cat)
    });
    if (!res.ok) throw new Error(await res.text());
  },

  getSpends: async (): Promise<Spend[]> => {
    const res = await fetch('/api/Spends');
    return await res.json();
  },

  getSpendsByDate: async (init: string, last: string): Promise<Spend[]> => {
    const res = await fetch(`/api/spends/search/date?init=${init}&last=${last}`)
    return res.json()
  },

  addSpend: async (spend: Omit<Spend, 'id'>): Promise<void> => {
    const res = await fetch('/api/Spends', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(spend)
    });
    if (!res.ok) throw new Error(await res.text());
  },

  getGeneralReport: async (): Promise<GeneralReport> => {
    const res = await fetch('/api/Report/general');
    return await res.json();
  },

  exportReport: (year: number, month: number) => {
    window.location.href = `api/report/export?year=${year}&month=${month}`;
  }
}