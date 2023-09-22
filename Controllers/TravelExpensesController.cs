using Microsoft.AspNetCore.Mvc;

namespace TravelEx.Controllers
{
    /// <summary>
    /// Controller for managing travel expenses.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class TravelExpensesController : ControllerBase
    {
        private readonly ILogger<TravelExpensesController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="TravelExpensesController"/> class.
        /// </summary>
        /// <param name="logger">The logger for the controller.</param>
        public TravelExpensesController(ILogger<TravelExpensesController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Retrieves all travel expenses using HttpGet.
        /// If not found, return 404 exit code, If found, return 200 exit code.
        /// </summary>
        /// <returns>A list of travel expenses.</returns>
        [HttpGet]
        [Route("get")]
        public IActionResult Get()
        {
            ITravelExpensesDAO te = new TravelExpensesDAO();
            var travelExpenses = te.getAll(); // Call the getAll() method to retrieve data
            if (travelExpenses == null)
            {
                return NotFound();
            }
            return StatusCode(200, travelExpenses);
        }

        /// <summary>
        /// Retrieves a travel expense by its ID using HttpGet.
        /// If not found, return 404 exit code, If found, return 200 exit code.
        /// </summary>
        /// <param name="id">The ID of the travel expense to retrieve.</param>
        /// <returns>The travel expense with the specified ID.</returns>
        [HttpGet]
        [Route("get/{id}")]
        public IActionResult GetById(int id)
        {
            // Retrieve the travel expense by ID
            var te = new TravelExpensesDAO();
            var travelExpense = te.getByID(id);

            if (travelExpense == null)
            {
                return NotFound(); // Return a 404 Not Found response if not found
            }
            return StatusCode(200, travelExpense);
        }

        /// <summary>
        /// Inserts a new travel expense record using HttpPost.
        /// </summary>
        /// <param name="travelExpenses">The travel expense to insert.</param>
        /// <returns>A status code indicating the result of the operation.</returns>
        [HttpPost]
        [Route("insert")]
        public IActionResult Insert([FromBody] TravelExpensesDTO travelExpenses)
        {
            // Check if the provided travelExpenses object is valid
            if (travelExpenses == null)
            {
                return StatusCode(400, "Bad Request for invalid input");// Return a 400 Bad Request for invalid input
            }

            // Insert the new record with a generated id
            var te = new TravelExpensesDAO();
            te.Insert(travelExpenses);

            // Return a response indicating success
            return StatusCode(200, "Insert successful");// 200 OK status code for a successful insertion
        }

        /// <summary>
        /// Deletes a travel expense by its ID.
        /// </summary>
        /// <param name="id">The ID of the travel expense to delete.</param>
        /// <returns>A status code indicating the result of the operation.</returns>
        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var dao = new TravelExpensesDAO();
            dao.Delete(id);

            return StatusCode(200, "Delete successful");
        }

        /// <summary>
        /// Updates an existing travel expense record.
        /// </summary>
        /// <param name="te">The updated travel expense.</param>
        /// <returns>A status code indicating the result of the operation.</returns>
        [HttpPost]
        [Route("update/{id}")]
        public IActionResult Update(TravelExpensesDTO te) 
        {
            var dao = new TravelExpensesDAO();
            dao.Update(te);
            return StatusCode(200, "Update successful");
        }
    }
}
