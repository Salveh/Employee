using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Hub.Models;

namespace Hub.Controllers
{
    public class EmployeeInfoController : Controller
    {
        // GET: EmployeeInfoController
        public async Task<ActionResult> index()
        {
            string apiUrl = "https://localhost:7283/api/employee";
            List<Employee> employee = new List<Employee>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                var result = await response.Content.ReadAsStringAsync();
                employee = JsonConvert.DeserializeObject<List<Employee>>(result);
            }

            return View(employee);
        }

        // GET: EmployeeInfoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeInfoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeInfoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Create(Employee employee)
        {
            string apiUrl = "https://localhost:7283/api/employee";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(employee);
        }


        // GET: EmployeeInfoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeeInfoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeInfoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeInfoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
