﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.SMTP
{
    public class EmailConfiguration
    {

        /// <summary>
        /// Хто відправляє листа
        /// </summary>
        public const string From = "jacobsmaksym@ukr.net";
        /// <summary>
        /// Адреса SMTP сервера
        /// </summary>
        public const string SmtpServer = "smtp.ukr.net";
        /// <summary>
        /// Порт на якому працює сервер
        /// </summary>
        public const int Port = 2525;
        /// <summary>
        /// Імя користувача для авторизації
        /// </summary>
        public const string UserName = "jacobsmaksym@ukr.net";
        /// <summary>
        /// Пароль, який видав сервер
        /// </summary>
        public const string Password = "oYmLaS4YVfOxVwAo";
    }
}
