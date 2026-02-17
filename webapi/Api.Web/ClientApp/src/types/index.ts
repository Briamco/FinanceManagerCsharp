export interface Category {
  id: number
  name: string
  monthBudget: number
}

export interface CategoryReport {
  categoryName: string
  total: number
  budget: number
  percent: number
}

export interface Spend {
  id: number
  description: string
  amount: number
  date: string
  categoryId: number
  category?: string
}

export interface GeneralReport {
  total: number
  categoriesReport: CategoryReport[]
  warnings: string[]
}