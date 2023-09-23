using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using TravelExpenses.BackEnd.Models;

namespace TravelExpenses.BackEnd.Data
{
    /// <summary>
    /// Represents a Data Access Object (DAO) for managing travel expenses.
    /// </summary>
    public class TravelExpensesDAO : ITravelExpensesDAO
    {
        private readonly DataSource ds;

        /// <summary>
        /// Initializes a new instance of the <see cref="TravelExpensesDAO"/> class.
        /// </summary>
        public TravelExpensesDAO()
        {
            ds = DataSource.GetInstance();
        }

        /// <inheritdoc />
        public void Delete(int id)
        {

            List<TravelExpensesDTO> dataset = ds.GetDataset();
            var deleteItem = dataset.FirstOrDefault(x => x.id == id);

            if (deleteItem != null)
            {
                dataset.Remove(deleteItem);
                ds.Commit(dataset);
            }
            else
            {
                throw new InvalidOperationException($"Item with ID {id} not found.");
            }
        }

        /// <inheritdoc />
        public List<TravelExpensesDTO> getAll()
        {
            List<TravelExpensesDTO> dataset = ds.GetDataset();

            List<TravelExpensesDTO> descDataset = new List<TravelExpensesDTO>(dataset);
            if (dataset != null)
            {
                if (dataset.First().id == descDataset.First().id)
                {
                    descDataset.Reverse(); // Reverse the list in-place
                }
            }
            else
            {
                throw new NullReferenceException("Cannot find the dataset");
            }
            return descDataset;
        }

        /// <inheritdoc />
        public TravelExpensesDTO getByID(int id)
        {
            List<TravelExpensesDTO> list = ds.GetDataset();
            if (list != null)
            {
                if(list.FirstOrDefault(x => x.id == id) != null){
                    return list.FirstOrDefault(x => x.id == id);
                }
                else
                {
                    throw new InvalidOperationException($"Item with ID {id} not found.");
                }
            }
            else
            {
                throw new ArgumentNullException("Cannot find the dataset");
            }
            
        }

        /// <inheritdoc />
        public List<TravelExpensesDTO> getByName(string name)
        {
            List<TravelExpensesDTO> dataset = ds.GetDataset();
            if (dataset != null)
            {
                if (dataset.Where(instance =>
                instance.ref_number.Equals(name, StringComparison.InvariantCultureIgnoreCase)) != null) 
                {
                    return dataset.Where(instance =>
                instance.ref_number.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                .ToList();
                }
                else
                {
                    throw new InvalidOperationException($"Item with ID {name} not found.");
                }
                
            }
            else
            {
                throw new ArgumentNullException("Cannot find the dataset");
            }
        }

        /// <inheritdoc />
        public List<TravelExpensesDTO> getByRefNumber(string refNumber)
        {
            List<TravelExpensesDTO> dataset = ds.GetDataset();
            if (dataset != null)
            {
                if (dataset.Where(instance =>
                instance.ref_number.Equals(refNumber, StringComparison.InvariantCultureIgnoreCase)) != null)
                {
                    return dataset.Where(instance =>
                instance.ref_number.Equals(refNumber, StringComparison.InvariantCultureIgnoreCase))
                .ToList();
                }
                else
                {
                    throw new InvalidOperationException($"Item with ID {refNumber} not found.");
                }
                
            }
            else
            {
                throw new ArgumentNullException("Cannot find the dataset");
            }
            
        }

        /// <inheritdoc />
        public void Insert(TravelExpensesDTO travelExpense)
        {
            List<TravelExpensesDTO> dataset = ds.GetDataset();
            if (dataset != null)
            {
                // Generate a unique ID for the new record
                int newId = dataset.Any() ? dataset.Max(item => item.id) + 1 : 1;

                travelExpense.id = newId;

                dataset.Add(travelExpense);
                try
                {
                    ds.Commit(dataset);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } else
            {
                throw new ArgumentNullException("Cannot find the dataset");
            }            
        }

        /// <inheritdoc />
        public void Update(TravelExpensesDTO travelExpense)
        {
            List<TravelExpensesDTO> dataset = ds.GetDataset();
            
            var updateItem = dataset.FirstOrDefault(x => x.id == travelExpense.id);
            if (dataset != null)
            {
                if (updateItem != null)
                {
                    PropertyInfo[] properties = typeof(TravelExpensesDTO).GetProperties();

                    foreach (PropertyInfo property in properties)
                    {
                        if (property.CanWrite)
                        {
                            object value = property.GetValue(travelExpense);

                            if (value != null && (!property.PropertyType.Equals(typeof(string)) || !string.IsNullOrEmpty((string)value)))
                            {
                                property.SetValue(updateItem, value);
                            }
                        }
                    }
                    try
                    {
                        ds.Commit(dataset);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    // Handle the case where the item with the provided ID is not found.
                    throw new InvalidOperationException($"Item with ID {travelExpense.id} not found.");
                }
            } else
            {
                throw new ArgumentNullException("Cannot find the dataset");
            }
            
        }
    }
}
