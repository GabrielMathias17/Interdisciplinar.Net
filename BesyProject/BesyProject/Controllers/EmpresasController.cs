﻿using BesyProject.Contexts;
using BesyProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BesyProject.Controllers
{
    public class EmpresasController : Controller
    {
        private EFContext context = new EFContext();

        // GET: Empresa
        public ActionResult Index()
        {
            return View(context
                .Empresas
                .OrderBy(c => c.Nome));
        }

        #region Create
    
        public ActionResult Create()
        {
            ViewBag.ServicoId = new SelectList(context
                .Servicos
                .OrderBy(b => b.Descricao), "ServicoId", "Descricao");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpresaId,Nome,Endereco,Telefone,Cnpj,Especialidade,ServicoId")] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                context.Empresas.Add(empresa);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ServicoId = new SelectList(context.Servicos, "ServicoId", "Descricao", empresa.ServicoId);
            return View(empresa);
        }

        #endregion

        #region Edit
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new
                HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Empresa empresa = context.Empresas.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            ViewBag.ServicoId = new SelectList(context
                .Servicos
                .OrderBy(b => b.Descricao), "ServicoId", "Descricao", empresa.ServicoId);
            
            return View(empresa);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                context.Entry(empresa).State =
                EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empresa);
        }

        #endregion

        #region Details
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Empresa empresa = context.Empresas.
            Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        #endregion

        #region Delete

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Empresa empresa = context.Empresas.
                Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Empresa empresa = context.Empresas.
            Find(id);
            context.Empresas.Remove(empresa);
            context.SaveChanges();
            TempData["Message"] = "Empresa	" + empresa.Nome.ToUpper()
                        + "	foi	removida";
            return RedirectToAction("Index");
        }

        #endregion

    }
}