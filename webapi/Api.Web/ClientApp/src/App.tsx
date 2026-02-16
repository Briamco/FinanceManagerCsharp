import SpendList from "./components/SpendList"
import CreateCategory from "./components/CreateCategory";
import CreateSpend from "./components/CreateSpend";
import Dashboard from "./components/Dashboard";
import { useAppManager } from "./hooks/useAppManager";

function App() {
  const { report, categories, spends, refreshData } = useAppManager();

  return (
    <div className="max-w-6xl mx-auto">
      <Dashboard report={report} />

      <section className="grid grid-cols-1 lg:grid-cols-3 gap-8">
        <article className="space-y-6">
          <CreateCategory onSaved={refreshData} />
          <CreateSpend categories={categories} onSaved={refreshData} />
        </article>

        <article className="lg:col-span-2 space-y-6">
          <SpendList spends={spends} />
        </article>
      </section>
    </div>
  )
}

export default App
