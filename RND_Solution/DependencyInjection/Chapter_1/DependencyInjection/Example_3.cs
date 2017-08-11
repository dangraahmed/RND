using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DependencyInjection.Chapter_1
{
    public class SecureMessageWriter : IMessageWriter
    {
        private readonly IMessageWriter writer;

        public SecureMessageWriter(IMessageWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }

            this.writer = writer;
        }

        public void Write(string message)
        {
            if (!Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                this.writer.Write(message);
            }
        }
    }

    public class Example_3
    {
        public static void MainFunction()
        {
            IMessageWriter writer = new SecureMessageWriter(new ConsoleMessageWriter());
            var salutation = new Salutation(writer);
            salutation.Exclaim();
        }
    }
}
