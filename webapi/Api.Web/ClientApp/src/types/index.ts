export interface Category {
  id: number
  name: string
  monthBudget: number
}

export interface Spend {
  id: number
  description: string
  amount: number
  date: Date
  categoryId: number
  category?: string
}

export interface GeneralReport {
  total: number
  warnings: string[]
}