import { useEffect, useState } from "react";
import type { Spend } from "../types";
import { apiService } from "../services/apiService";

const SpendList = () => {
  const [spends, setSpends] = useState<Spend[]>([]);
  const [loading, setLoading] = useState(true);

  const [filterInit, setFilterInit] = useState<string>('');
  const [filterLast, setFilterLast] = useState<string>('');

  useEffect(() => {
    apiService.getSpends()
      .then(data => setSpends(data))
      .catch(err => console.error(err))
      .finally(() => setLoading(false));
  }, []);

  if (loading) return <div>Cargando gastos...</div>;

  async function handleFilterDate() {
    if (!filterInit || !filterLast) {
      alert('Por favor, selecciona ambas fechas para filtrar.');
      return;
    }

    try {
      const filteredSpends = await apiService.getSpendsByDate(filterInit, filterLast);
      setSpends(filteredSpends);
    } catch (error) {
      console.error('Error al filtrar gastos por fecha:', error);
      alert('Ocurrió un error al filtrar los gastos. Por favor, intenta nuevamente.');
    }
  }

  return (
    <section className="bg-white p-6 rounded-xl shadow-sm border">
      <div className="flex flex-wrap justify-between items-center mb-6 gap-4">
        <h2 className="text-xl font-bold">Historial de Gastos</h2>
        <div className="flex gap-2">
          <input type="date" onChange={(e) => setFilterInit(e.target.value)} className="p-1 border rounded text-xs" />
          <input type="date" onChange={(e) => setFilterLast(e.target.value)} className="p-1 border rounded text-xs" />
          <button onClick={() => handleFilterDate()} className="bg-slate-100 px-2 py-1 rounded text-xs border">📅 Filtrar</button>
        </div>
      </div>

      <ul id="list-spends" className="divide-y divide-slate-100">
        {spends.map(s => (
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