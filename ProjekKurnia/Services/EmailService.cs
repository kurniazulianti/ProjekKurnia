﻿using Microsoft.Extensions.Options;
using ProjekKurnia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ProjekKurnia.Services
{
    public class EmailService
    {
        private readonly IOptions<Email> _dariJson;
        public EmailService(IOptions<Email> em)
        {
            _dariJson = em;
        }

        public bool KirimEmail(string tujuan, string judulEmail, string isiEmail)
        {
            try
            {

                Email e = new Email();
                e.NamaClientnya = _dariJson.Value.NamaClientnya;
                e.Portnya = _dariJson.Value.Portnya;
                e.EmailKita = _dariJson.Value.EmailKita;
                e.PasswordEmailKita = _dariJson.Value.PasswordEmailKita;

                MailMessage m = new MailMessage();
                m.From = new MailAddress(e.EmailKita);
                m.Subject = judulEmail;
                m.Body = isiEmail;
                m.IsBodyHtml = true;
                m.To.Add(tujuan);

                SmtpClient s = new SmtpClient(e.NamaClientnya);
                s.Port = e.Portnya;
                s.Credentials = new System.Net.NetworkCredential(e.EmailKita, e.PasswordEmailKita);
                s.EnableSsl = true;
                s.Send(m);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
