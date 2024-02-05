using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bank_Simulation.Data;
using Bank_Simulation.ViewModels;
using Bank_simulation.Models;
using Bank_Simulation.Models;

namespace Bank_Simulation.Controllers
{
    public class RegistrationViewModelsController : Controller
    {
        private readonly Bank_SimulationContext _context;


        public RegistrationViewModelsController(Bank_SimulationContext context)
        {
            _context = context;
        }

        public IActionResult TestpartialView()
        {
            return PartialView("_ConfirmationCreatingAccount");
        }
    
        // GET: RegistrationViewModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.AccountsTypes.ToListAsync());
        }

        // GET: RegistrationViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registrationViewModel = await _context.RegistrationViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registrationViewModel == null)
            {
                return NotFound();
            }

            return View(registrationViewModel);
        }

        // GET: RegistrationViewModels/Create
        public  IActionResult Create()
        {
   

          
            ViewBag.ListAccountType = _context.AccountsTypes.Select(x=>new SelectListItem {
                
                Text = x.Name,
                Value = x.Id.ToString()

            } ).ToList();
         

            


            return View();
        }

        // POST: RegistrationViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegistrationViewModel registrationViewModel,TypeAccount account)
        {
           var motherfucker= registrationViewModel;
            var the = account;
            if (ModelState.IsValid)
            { 
             
                _context.Client.Add(
                    new Client() {
                        FirsName=registrationViewModel.FirstName,
                        LastName=registrationViewModel.LastName,
                        Street=registrationViewModel.Street,
                        StreetNumber=registrationViewModel.StreetNumber,
                        PostCode=registrationViewModel.PostCode,
                        City=registrationViewModel.City,
                        PhoneNumber=registrationViewModel.PhoneNumber,
                        Email=registrationViewModel.Email,
                        Pesel=registrationViewModel.Pesel,
                        IDNumber=registrationViewModel.NumberId,
                        typeAcccountId=registrationViewModel.typeAccount.Id
                    }
                    );
      
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(registrationViewModel);
        }

      

        // GET: RegistrationViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registrationViewModel = await _context.RegistrationViewModel.FindAsync(id);
            if (registrationViewModel == null)
            {
                return NotFound();
            }
            return View(registrationViewModel);
        }

        // POST: RegistrationViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FirstName,LastName,City,Street,StreetNumber,PostCode,PhoneNumber,Email,Pesel,FirsName,Created,IDNumber,Id")] RegistrationViewModel registrationViewModel)
        {
            if (id != registrationViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registrationViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistrationViewModelExists(registrationViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(registrationViewModel);
        }

        // GET: RegistrationViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registrationViewModel = await _context.RegistrationViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registrationViewModel == null)
            {
                return NotFound();
            }

            return View(registrationViewModel);
        }

        // POST: RegistrationViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registrationViewModel = await _context.RegistrationViewModel.FindAsync(id);
            if (registrationViewModel != null)
            {
                _context.RegistrationViewModel.Remove(registrationViewModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistrationViewModelExists(int id)
        {
            return _context.RegistrationViewModel.Any(e => e.Id == id);
        }
    }
}
