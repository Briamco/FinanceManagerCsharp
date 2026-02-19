import SpendList from "./components/SpendList";
import CreateCategory from "./components/CreateCategory";
import CreateSpend from "./components/CreateSpend";
import Dashboard from "./components/Dashboard";
import { useAppManager } from "./hooks/useAppManager";
import CategoryPieChart from "./components/CategoryPieChart";
import BudgetGauge from "./components/BudgetGauge";
import CategoryList from "./components/CategoryList";

function App() {
  const { report, categories, spends, refreshData } = useAppManager();

  return (
    <div className="max-w-7xl mx-auto p-4">
      <Dashboard report={report} />

      <main className="grid grid-cols-1 lg:grid-cols-4 gap-8 mt-8 align-start">

        <aside className="lg:col-span-1 space-y-6">
          <div className="bg-white p-4 rounded-lg shadow-sm space-y-6">
            <CreateCategory onSaved={refreshData} />
            <CreateSpend categories={categories} onSaved={refreshData} />
          </div>

          <div className="bg-white rounded-lg shadow-sm">
            <CategoryList categories={categories} onSaved={refreshData} />
          </div>
        </aside>

        <section className="lg:col-span-2">
          <div className="bg-white rounded-lg shadow-sm">
            <SpendList spends={spends} categories={categories} />
          </div>
        </section>

        <aside className="lg:col-span-1">
          <div className="sticky top-8 space-y-6">
            <h2 className="text-xl font-bold text-slate-800 px-2">Análisis</h2>

            <div className="bg-white p-4 rounded-lg shadow-sm">
              <CategoryPieChart data={report?.categoriesReport || []} />
            </div>

            <article className="space-y-4">
              <h3 className="font-bold text-slate-700 px-2">Límites</h3>
              <div className="space-y-4">
                {report?.categoriesReport.map((c) => (
                  <BudgetGauge
                    key={c.categoryName}
                    name={c.categoryName}
                    spended={c.total}
                    budget={c.budget}
                  />
                ))}
              </div>
            </article>
          </div>
        </aside>

      </main>
    </div>
  );
}

export default App;