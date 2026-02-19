import type { Category, GeneralReport, Spend } from "../types";

/**
 * Servicio para realizar peticiones a la API del backend.
 * Proporciona métodos para interactuar con los endpoints de categorías, gastos y reportes.
 */
export const apiService = {
  /**
   * Obtiene todas las categorías.
   * @returns Promise con el array de categorías
   */
  getCategory: async (): Promise<Category[]> => {
    const res = await fetch('/api/category')
    return await res.json()
  },

  /**
   * Agrega una nueva categoría.
   * @param cat - Datos de la categoría (sin el ID)
   * @throws Error si la petición falla
   */
  addCategory: async (cat: Omit<Category, 'id'>): Promise<void> => {
    const res = await fetch('/api/Category', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(cat)
    });
    if (!res.ok) throw new Error(await res.text());
  },

  /**
   * Actualizar una categoria
   * @param id  - ID de la categoria
   * @param cat - Datos de la categoria (sin el ID)
   * @throws Error si la peticion falla
   */
  updateCategory: async (id: number, cat: Omit<Category, 'id'>): Promise<void> => {
    const res = await fetch(`/api/Category/${id}`, {
      method: 'PATCH',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(cat)
    })
    if (!res.ok) throw new Error(await res.text());
  },

  /**
   * 
   * @param id - ID de la categoria
   * @throws Error si la peticion falla
   */
  deleteCategory: async (id: number) => {
    const res = await fetch(`/api/Category/${id}`, {
      method: 'DELETE',
    })
    if (!res.ok) throw new Error(await res.text())
  },

  /**
   * Obtiene todos los gastos.
   * @returns Promise con el array de gastos
   */
  getSpends: async (): Promise<Spend[]> => {
    const res = await fetch('/api/Spends');
    return await res.json();
  },

  /**
   * Obtiene los gastos filtrados por rango de fechas.
   * @param init - Fecha inicial en formato ISO
   * @param last - Fecha final en formato ISO
   * @returns Promise con el array de gastos filtrados
   */
  getSpendsByDate: async (init: string, last: string): Promise<Spend[]> => {
    const res = await fetch(`/api/spends/search/date?init=${init}&last=${last}`)
    return res.json()
  },

  /**
   * 
   * @param categoryId - ID de la categoria
   * @returns Promise con el array de gastos filtrados
   */
  getSpendsByCategory: async (categoryId: number): Promise<Spend[]> => {
    const res = await fetch(`/api/spends/search/category/${categoryId}`)
    return res.json()
  },

  /**
   * Agrega un nuevo gasto.
   * @param spend - Datos del gasto (sin el ID)
   * @throws Error si la petición falla
   */
  addSpend: async (spend: Omit<Spend, 'id'>): Promise<void> => {
    const res = await fetch('/api/Spends', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(spend)
    });
    if (!res.ok) throw new Error(await res.text());
  },

  /**
   * Obtiene el reporte general de gastos.
   * @returns Promise con el reporte general
   */
  getGeneralReport: async (): Promise<GeneralReport> => {
    const res = await fetch('/api/Report/general');
    return await res.json();
  },

  /**
   * Exporta un reporte mensual en formato JSON.
   * Descarga el archivo automáticamente.
   * @param year - Año del reporte
   * @param month - Mes del reporte (1-12)
   */
  exportReport: (year: number, month: number) => {
    window.location.href = `api/report/export?year=${year}&month=${month}`;
  }
}