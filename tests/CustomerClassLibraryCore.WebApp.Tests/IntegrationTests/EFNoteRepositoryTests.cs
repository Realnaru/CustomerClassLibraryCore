using CustomerClassLibraryCore.BusinessEntities;
using CustomerClassLibraryCore.Data.EFData;
using CustomerClassLibraryCore.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerClassLibraryCore.WebApp.Tests.IntegrationTests
{
    public class EFNoteRepositoryTests
    {
        [Fact]
        public void ShouldBeAbleToCreateEFNoteRepository()
        {
            var noteRepository = new EFNoteRepository();
            Assert.NotNull(noteRepository);
        }

        [Fact]
        public void ShouldbeAbleToCreateCustomerNote()
        {
            var customerNoteRepository = new EFNoteRepository();
            var customerRepository = new EFCustomerRepository();

            customerRepository.DeleteAll();

            var customerNote = new CustomerNote();
            var fixture = new EFCustomerRepositoryFixture();
            var customer = fixture.CreateMockCustomer();
            int customerId = customer.CustomerId;

            customerNote.CustomerId = customerId;
            customerNote.Note = "Kitty ipsum dolor sit amet, shed everywhere shed everywhere";

            int customerNoteId = customerNoteRepository.Create(customerNote);
            Assert.NotEqual(0, customerNoteId);
        }

        [Fact]
        public void ShouldbeAbleToReadCustomerNote()
        {
            var customerNoteRepository = new EFNoteRepository();
            var customerRepository = new EFCustomerRepository();
            var fixture = new EFCustomerRepositoryFixture();

            customerRepository.DeleteAll();

            var customerNote = new CustomerNote();

            var customer = fixture.CreateMockCustomer();
            int customerId = customer.CustomerId;

            customerNote.CustomerId = customerId;
            customerNote.Note = "Kitty ipsum dolor sit amet, shed everywhere shed everywhere";

            int noteId = customerNoteRepository.Create(customerNote);

            var createdNote = customerNoteRepository.Read(noteId);

            Assert.NotNull(createdNote);
            Assert.Equal(customerId, createdNote.CustomerId);
            Assert.Equal("Kitty ipsum dolor sit amet, shed everywhere shed everywhere", createdNote.Note);
        }

        [Fact]
        public void ShouldbeAbleToUpdateCustomerNote()
        {
            var customerNoteRepository = new EFNoteRepository();
            var customerRepository = new EFCustomerRepository();
            var fixture = new EFCustomerRepositoryFixture();

            customerRepository.DeleteAll();

            var customerNote = new CustomerNote();

            var customer = fixture.CreateMockCustomer();
            int customerId = customer.CustomerId;

            customerNote.CustomerId = customerId;
            customerNote.Note = "Kitty ipsum dolor sit amet, shed everywhere shed everywhere";

            int noteId = customerNoteRepository.Create(customerNote);

            customerNote.NoteId = noteId;
            customerNote.Note = "Purr jum eat the grass rip the couch scratched sumbathe, shed everywhere rip the couch sleep in the sink fluffy fur canip scratched";
            customerNoteRepository.Update(customerNote);

            var createdNote = customerNoteRepository.Read(noteId);

            Assert.NotNull(createdNote);
            Assert.Equal(customerId, createdNote.CustomerId);
            Assert.Equal("Purr jum eat the grass rip the couch scratched sumbathe, shed everywhere rip the couch sleep in the sink fluffy fur canip scratched", createdNote.Note);
        }

        [Fact]
        public void ShouldbeAbleToDeleteCustomerNote()
        {
            var customerNoteRepository = new EFNoteRepository();
            var customerRepository = new EFCustomerRepository();
            var fixture = new EFCustomerRepositoryFixture();

            customerRepository.DeleteAll();

            var customerNote = new CustomerNote();

            var customer = fixture.CreateMockCustomer();
            int customerId = customer.CustomerId;

            customerNote.CustomerId = customerId;
            customerNote.Note = "Kitty ipsum dolor sit amet, shed everywhere shed everywhere";

            int noteId = customerNoteRepository.Create(customerNote);

            customerNoteRepository.Delete(noteId);

            var deletedNote = customerNoteRepository.Read(customerNote.CustomerId);

            Assert.Null(deletedNote);
        }

    }
}
