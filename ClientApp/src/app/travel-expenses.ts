/**
 * Interface defining the structure of a TravelExpensesDTO (Travel Expenses Data Transfer Object) object.
 */
export interface TravelExpensesDTO {
  id?: number; // Optional ID field
  ref_number: string; // Reference number
  title_en: string; // Title in English
  purpose_en: string; // Purpose in English
  start_date: string; // Start date
  end_date: string; // End date
  airfare: number; // Airfare expenses
  other_transport: number; // Other transportation expenses
  lodging: number; // Lodging expenses
  meals: number; // Meals expenses
  other_expenses: number; // Other miscellaneous expenses
  total: number; // Total expenses
}
