/* eslint-disable react-hooks/set-state-in-effect */
import { useState, useEffect, useCallback } from 'react';
import { apiService } from '../services/apiService';
import type { Category, GeneralReport, Spend } from '../types';


export const useAppManager = () => {
  const [spends, setSpends] = useState<Spend[]>([]);
  const [categories, setCategories] = useState<Category[]>([]);
  const [report, setReport] = useState<GeneralReport | null>(null);

  // Función central para recargar TODO
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

  useEffect(() => {
    refreshData();
  }, [refreshData]);

  return { spends, categories, report, refreshData };
};