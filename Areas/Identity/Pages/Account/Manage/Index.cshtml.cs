// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using MesDoigtsDeFees.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MesDoigtsDeFees.Areas.Identity.Pages.Account.Manage
{
  

  
        public class IndexModel : PageModel
        {
            private readonly UserManager<MesDoigtsDeFeesUser> _userManager;
            private readonly SignInManager<MesDoigtsDeFeesUser> _signInManager;

            public IndexModel(
                UserManager<MesDoigtsDeFeesUser> userManager,
                SignInManager<MesDoigtsDeFeesUser> signInManager)
            {
                _userManager = userManager;
                _signInManager = signInManager;
            }

            [BindProperty]
            public InputModel Input { get; set; }

            public class InputModel
            {
                [Display(Name = "First Name")]
                public string FirstName { get; set; }

                [Display(Name = "Last Name")]
                public string LastName { get; set; }

                [EmailAddress]
                [Display(Name = "Email")]
                public string Email { get; set; }
            }

            private async Task LoadAsync(MesDoigtsDeFeesUser user)
            {
                Input = new InputModel
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email
                };
            }

            public async Task<IActionResult> OnGetAsync()
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
                }

                await LoadAsync(user);
                return Page();
            }

            public async Task<IActionResult> OnPostAsync()
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
                }

                if (!ModelState.IsValid)
                {
                    return Page();
                }

                user.FirstName = Input.FirstName;
                user.LastName = Input.LastName;
                user.Email = Input.Email;

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToPage("./Profile"); // Redirect to profile page after successful update
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return Page();
            }
        }
    }

