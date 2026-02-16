/* eslint-disable react-hooks/set-state-in-effect */
import { useEffect, useState } from "react";
import { apiService } from "../services/apiService";
import type { GeneralReport } from "../types";

interface Props {
  report: GeneralReport | null
}

const Dashboard = ({ report }: Props) => {
  const [yearValue, setYearValue] = useState<number>(0);
  const [monthValue, setMonthValue] = useState<number>(0);

  useEffect(() => {
    const today = new Date();
    setYearValue(today.getFullYear());
    setMonthValue(today.getMonth() + 1);
  }, [])

  const handleExport = () => {
    if (!monthValue || !yearValue) {
      alert('Por favor, ingresa un mes y año válidos para exportar.');
      return;
    }

    apiService.exportReport(yearValue, monthValue)
  }

  return (
    <>
      <header className="flex justify-between items-center mb-8 border-b pb-4">
        <h1 className="text-3xl font-extrabold text-slate-800">Finance<span className="text-blue-600">Manager</span></h1>
        <div className="flex gap-2">
          <input type="number" onChange={(e) => setYearValue(Number(e.target.value))} id="exp-year" placeholder="Año" className="w-20 p-2 border rounded text-sm" value={yearValue} />
          {/* <input type="number" onChange={(e) => setMonthValue(Number(e.target.value))} id="exp-month" placeholder="Mes" className="w-16 p-2 border rounded text-sm" value={monthValue} /> */}
          <select className="w-fit p-2 border rounded text-sm" value={monthValue} onChange={(e) => setMonthValue(Number(e.target.value))}>
            <option value="1">Enero</option>
            <option value="2">Febrero</option>
            <option value="3">Marzo</option>
            <option value="4">Abril</option>
            <option value="5">Mayo</option>
            <option value="6">Junio</option>
            <option value="7">Julio</option>
            <option value="8">Agosto</option>
            <option value="9">Septiembre</option>
            <option value="10">Octubre</option>
            <option value="11">Noviembre</option>
            <option value="12">Diciembre</option>
          </select>
          <button onClick={() => handleExport()} className="bg-green-600 text-white px-4 py-2 rounded text-sm hover:bg-green-700">Exportar JSON</button>
        </div>
      </header>

      <section className="grid grid-cols-1 md:grid-cols-3 gap-4 mb-8">
        <article className="bg-blue-600 text-white p-6 rounded-xl shadow-lg">
          <p className="opacity-80 text-sm">Gasto Total General</p>
          <p className="text-3xl font-bold">${report?.total.toLocaleString()}</p>
        </article>
        <article className="bg-white p-6 rounded-xl shadow-sm border col-span-2">
          <h3 className="font-bold mb-2">Alertas de Presupuesto</h3>
          <div className="space-y-1">
            {
              report?.warnings.length
                ? report.warnings.map(a => <p key={a} className="text-red-500 text-sm">⚠️ {a}</p>)
                : <p className="text-green-500 text-sm">✅ Todo bajo control</p>
            }
          </div>
        </article>
      </section>
    </>
  );
}

export default Dashboard