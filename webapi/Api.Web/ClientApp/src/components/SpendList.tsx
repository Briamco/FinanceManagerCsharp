import { useEffect, useState } from "react";
import type { Spend } from "../types";
import { apiService } from "../services/apiService";

/**
 * Props del componente SpendList.
 */
interface Props {
  /** Lista de gastos a mostrar */
  spends: Spend[]
}

/**
 * Componente que muestra la lista de gastos.
 * Incluye funcionalidad de filtrado por rango de fechas.
 * Muestra la descripción, categoría, fecha y monto de cada gasto.
 * 
 * @param props - Props del componente
 */
const SpendList = ({ spends }: Props) => {
  const [spendsFiltered, setSpendsFiltered] = useState<Spend[]>([]);

  // Sincronizar la lista filtrada con los gastos recibidos
  useEffect(() => {
    setSpendsFiltered(spends);
  }, [spends])

  const [filterInit, setFilterInit] = useState<string>('');
  const [filterLast, setFilterLast] = useState<string>('');

  /**
   * Filtra los gastos por rango de fechas.
   * Valida que se hayan seleccionado ambas fechas antes de filtrar.
   */
  async function handleFilterDate() {
    if (!filterInit || !filterLast) {
      alert('Por favor, selecciona ambas fechas para filtrar.');
      return;
    }

    try {
      const filteredSpends = await apiService.getSpendsByDate(filterInit, filterLast);
      setSpendsFiltered(filteredSpends);
    } catch (error) {
      console.error('Error al filtrar gastos por fecha:', error);
      alert('Ocurrió un error al filtrar los gastos. Por favor, intenta nuevamente.');
    }
  }

  return (
    <section className="bg-white p-6 rounded-xl shadow-sm border">
      <div className="flex flex-wrap justify-between items-center mb-6 gap-4">
        <h2 className="text-xl font-bold">Historial de Gastos</h2>
        {/* Controles de filtrado por fecha */}
        <div className="flex gap-2">
          <input type="date" onChange={(e) => setFilterInit(e.target.value)} className="p-1 border rounded text-xs" />
          <input type="date" onChange={(e) => setFilterLast(e.target.value)} className="p-1 border rounded text-xs" />
          <button onClick={() => handleFilterDate()} className="bg-slate-100 px-2 py-1 rounded text-xs border">📅 Filtrar</button>
        </div>
      </div>

      {/* Lista de gastos */}
      <ul id="list-spends" className="divide-y divide-slate-100">
        {spendsFiltered.map(s => (
          <li key={s.id} className="py-3 flex justify-between items-center">
            <div>
              <p className="font-medium text-slate-800">{s.description}</p>
              <p className="text-xs text-slate-400">{s.category} | {new Date(s.date).toLocaleDateString()}</p>
            </div>
            <span className="text-lg font-bold text-slate-700">${s.amount.toLocaleString()}</span>
          </li>
        ))}
      </ul>
    </section>
  )
}

export default SpendList;