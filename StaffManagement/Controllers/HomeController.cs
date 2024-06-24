﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using StaffManagement.Models;
using StaffManagement.ViewModels;
using System;
using System.IO;

namespace StaffManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStaffRepository _staffRepository;
        private readonly IWebHostEnvironment webHost;

        public HomeController(IStaffRepository staffRepository, IWebHostEnvironment webHost)
        {
            _staffRepository = staffRepository;
            this.webHost = webHost;
        }

        public ViewResult Index()
        {
            HomeIndexViewModel viewModel = new HomeIndexViewModel()
            {
                Staffs = _staffRepository.GetAll(),
            };
            return View(viewModel);
        }

        public ViewResult Details(int id)
        {
            Staff staff = _staffRepository.Get(id);
            if (staff != null)
            {
                HomeDetailsViewModel viewModel = new HomeDetailsViewModel()
                {
                    Staff = staff,
                    Title = "Staff Details",
                };

                return View(viewModel);
            }
            else
            {
                return NotFoundView(id);
            }


            
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Staff staff = _staffRepository.Get(id);
            if (staff != null)
            {

                HomeEditViewModel editViewModel = new HomeEditViewModel()
                {
                    Id = staff.Id,
                    FirstName = staff.FirstName,
                    LastName = staff.LastName,
                    Email = staff.Email,
                    Department = staff.Department,
                    ExistingPhotoPath = staff.PhotoFilePath
                };

                return View(editViewModel);
            }
            else
            {
                return NotFoundView(id);
            }

        }

        [HttpPost]
        public IActionResult Create(HomeCreateViewModel staff)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadFile(staff);

                Staff newStaff = new Staff
                {
                    FirstName = staff.FirstName,
                    LastName = staff.LastName,
                    Email = staff.Email,
                    Department = staff.Department,
                    PhotoFilePath = uniqueFileName
                };

                newStaff = _staffRepository.Create(newStaff);
                return RedirectToAction("details", new { id = newStaff.Id });
            }

            return View();

        }

        [HttpPost]
        public IActionResult Edit(HomeEditViewModel staff)
        {
            if (ModelState.IsValid)
            {
                Staff existingStaff = _staffRepository.Get(staff.Id);

                existingStaff.FirstName = staff.FirstName;
                existingStaff.LastName = staff.LastName;
                existingStaff.Email = staff.Email;
                existingStaff.Department = staff.Department;
                existingStaff.PhotoFilePath = staff.ExistingPhotoPath;

                if (staff.Photo != null)
                {
                    if (staff.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(webHost.WebRootPath, "images", staff.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    existingStaff.PhotoFilePath = ProcessUploadFile(staff);
                }

                _staffRepository.Update(existingStaff);
                return RedirectToAction("details", new { id = existingStaff.Id });
            }

            return View();

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Staff staff = _staffRepository.Get(id);
            if (staff != null)
            {
                _staffRepository.Delete(id);
                return RedirectToAction("index");
            }
            else
            {
                return NotFoundView(id);
            }

        }

        private ViewResult NotFoundView(int id)
        {
            Response.StatusCode = 404;
            return View("StaffNotFound", id);
        }

        private string ProcessUploadFile(HomeCreateViewModel staff)
        {
            string uniqueFileName = string.Empty;
            if (staff.Photo != null)
            {
                string uploadFolder = Path.Combine(webHost.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + staff.Photo.FileName;
                string imageFilePath = Path.Combine(uploadFolder, uniqueFileName);

                using (var fileName = new FileStream(imageFilePath, FileMode.Create))
                {
                    staff.Photo.CopyTo(fileName);
                }

            }

            return uniqueFileName;
        }
    }
}
