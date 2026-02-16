import { useState } from "react";
import SpendList from "./components/SpendList"
import { apiService } from "./services/apiService";
import CreateCategory from "./components/CreateCategory";
import CreateSpend from "./components/CreateSpend";

function App() {
  const [monthValue, setMonthValue] = useState<number>(0);
  const [yearValue, setYearValue] = useState<number>(0);

  const handleExport = () => {
    if (!monthValue || !yearValue) {
      alert('Por favor, ingresa un mes y año válidos para exportar.');
      return;
    }

    apiService.exportReport(yearValue, monthValue)
  }

  return (
    <div className="max-w-6xl mx-auto">
      <header className="flex justify-between items-center mb-8 border-b pb-4">
        <h1 className="text-3xl font-extrabold text-slate-800">Finance<span className="text-blue-600">Manager</span></h1>
        <div className="flex gap-2">
          <input type="number" onChange={(e) => setYearValue(Number(e.target.value))} id="exp-year" placeholder="Año" className="w-20 p-2 border rounded text-sm" value="2026" />
          <input type="number" onChange={(e) => setMonthValue(Number(e.target.value))} id="exp-month" placeholder="Mes" className="w-16 p-2 border rounded text-sm" value="2" />
          <button onClick={() => handleExport()} className="bg-green-600 text-white px-4 py-2 rounded text-sm hover:bg-green-700">Exportar JSON</button>
        </div>
      </header>

      <section className="grid grid-cols-1 lg:grid-cols-3 gap-8">

        <article className="space-y-6">
          <CreateCategory />
          <CreateSpend />
        </article>

        <article className="lg:col-span-2 space-y-6">
          <SpendList />
        </article>
      </section>
    </div>
  )
}

export default App
