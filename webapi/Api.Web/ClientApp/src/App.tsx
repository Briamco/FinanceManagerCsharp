import SpendList from "./components/SpendList"
import CreateCategory from "./components/CreateCategory";
import CreateSpend from "./components/CreateSpend";
import Dashboard from "./components/Dashboard";
import { useAppManager } from "./hooks/useAppManager";
import CategoryPieChart from "./components/CategoryPieChart";
import BudgetGauge from "./components/BudgetGauge";

function App() {
  const { report, categories, spends, refreshData } = useAppManager();

  return (
    <div className="max-w-6xl mx-auto">
      <Dashboard report={report} />

      <section className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-8">
        <aside className="space-y-6">
          <CreateCategory onSaved={refreshData} />
          <CreateSpend categories={categories} onSaved={refreshData} />
        </aside>

        <main className="lg:col-span-2 space-y-6">
          <SpendList spends={spends} />
        </main>

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
