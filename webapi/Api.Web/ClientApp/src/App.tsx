import SpendList from "./components/SpendList"
import CreateCategory from "./components/CreateCategory";
import CreateSpend from "./components/CreateSpend";
import Dashboard from "./components/Dashboard";
import { useAppManager } from "./hooks/useAppManager";
import CategoryPieChart from "./components/CategoryPieChart";
import BudgetGauge from "./components/BudgetGauge";

/**
 * Componente principal de la aplicación FinanceManager.
 * Organiza el layout y la distribución de los componentes principales:
 * - Dashboard con el reporte general
 * - Formularios para crear categorías y registrar gastos
 * - Lista de gastos
 * - Gráficos y medidores de presupuesto
 * 
 * Utiliza el hook useAppManager para gestionar el estado global.
 */
function App() {
  const { report, categories, spends, refreshData } = useAppManager();

  return (
    <div className="max-w-6xl mx-auto">
      <Dashboard report={report} />

      <section className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-8">
        {/* Panel izquierdo: Formularios */}
        <aside className="space-y-6">
          <CreateCategory onSaved={refreshData} />
          <CreateSpend categories={categories} onSaved={refreshData} />
        </aside>

        {/* Panel central: Lista de gastos */}
        <main className="lg:col-span-2 space-y-6">
          <SpendList spends={spends} />
        </main>

        {/* Panel derecho: Análisis y gráficos */}
        <aside className="space-y-6 lg:col-span-1">
          <div className="sticky top-8 space-y-6">
            <h2 className="text-xl font-bold text-slate-800 px-2">Análisis</h2>

            <CategoryPieChart data={report?.categoriesReport || []} />

            <article className="space-y-4">
              <h3 className="font-bold mb-4">Limites</h3>
              {
                report?.categoriesReport.map(c => (
                  <BudgetGauge
                    key={c.categoryName}
                    name={c.categoryName}
                    spended={c.total}
                    budget={c.budget}
                  />
                ))
              }
            </article>
          </div>
        </aside>
      </section>
    </div >
  )
}

export default App
