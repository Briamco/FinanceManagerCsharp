/* eslint-disable react-hooks/set-state-in-effect */
import { useState, useEffect, useCallback } from 'react';
import { apiService } from '../services/apiService';
import type { Category, GeneralReport, Spend } from '../types';

/**
 * Hook personalizado para gestionar el estado global de la aplicación.
 * Centraliza la obtención de datos de gastos, categorías y reportes.
 * 
 * @returns Objeto con los datos de la aplicación y la función para refrescar
 */
export const useAppManager = () => {
  const [spends, setSpends] = useState<Spend[]>([]);
  const [categories, setCategories] = useState<Category[]>([]);
  const [report, setReport] = useState<GeneralReport | null>(null);

  /**
   * Función central para recargar todos los datos desde la API.
   * Realiza las peticiones en paralelo para mejor rendimiento.
   */
  const refreshData = useCallback(async () => {
    try {
      const [s, c, r] = await Promise.all([
        apiService.getSpends(),
        apiService.getCategory(),
        apiService.getGeneralReport()
      ]);
      setSpends(s);
      setCategories(c);
      setReport(r);
    } catch (err) {
      console.error("Error al refrescar datos:", err);
    }
  }, []);

  // Carga inicial de datos al montar el componente
  useEffect(() => {
    refreshData();
  }, [refreshData]);

  return { spends, categories, report, refreshData };
};