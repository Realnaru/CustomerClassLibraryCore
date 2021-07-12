using CustomerClassLibraryCore.BusinessEntities;
using CustomerClassLibraryCore.Common;
using CustomerClassLibraryCore.Data.EFData;
using CustomerClassLibraryCore.Data.Repositories;
using CustomerClassLibraryCore.Repositories;
using CustomerClassLibraryCore.WebApp.Tests.IntegrationTests;
using CustomerClassLibraryWebApp.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerClassLibraryCore.WebApp.Tests
{
    public class NotesControllerTests
    {
        [Fact]
        public void ShouldBeAbleToCreateNotesController()
        {
            var controller = new NotesController(new EFCustomerRepository(), new EFNoteRepository());
            Assert.NotNull(controller);
        }

        //[Fact]
        //public void ShouldBeAbleToGetAllNotes()
        //{
        //    var noteRepositoryMock = new Mock<IEntityRepository<CustomerNote>>();
        //    var customerRepositoryMock = new Mock<IEntityRepository<Customer>>();

        //    var note = new CustomerNote()
        //    {
        //        CustomerId = 1,
        //        Note = "Kitty Ipsum"
        //    };

        //    var secondNote = new CustomerNote()
        //    {
        //        CustomerId = 1,
        //        Note = "Kitty Ipsum"
        //    };

        //    noteRepositoryMock.Setup(x => x.ReadAll()).Returns(new List<CustomerNote>() { note, secondNote });

        //    var controller = new NotesController(customerRepositoryMock.Object, noteRepositoryMock.Object);

        //    var notes = controller.Get().ToList();

        //    Assert.Equal(note, notes[0]);
        //    Assert.Equal(secondNote, notes[1]);
        //}


        [Fact]
        public void ShouldBeAbleToGetNote()
        {
            var noteRepositoryMock = new Mock<IEntityRepository<CustomerNote>>();
            var customerRepositoryMock = new Mock<IEntityRepository<Customer>>();

            var note = new CustomerNote()
            {
                CustomerId = 1,
                Note = "Kitty Ipsum"
            };

            noteRepositoryMock.Setup(x => x.Read(1)).Returns(note);

            var controller = new NotesController(customerRepositoryMock.Object, noteRepositoryMock.Object);

            var fetchedNote = controller.Get(1);

            Assert.NotNull(fetchedNote);           
        }

        [Fact]
        public void ShouldBeAbleToGetAllNotesByCustomerId()
        {
            var noteRepositoryMock = new Mock<IEntityRepository<CustomerNote>>();
            var customerRepositoryMock = new Mock<IEntityRepository<Customer>>();

            var note = new CustomerNote()
            {
                CustomerId = 1,
                Note = "Kitty Ipsum"
            };

            var secondNote = new CustomerNote()
            {
                CustomerId = 1,
                Note = "Kitty Ipsum"
            };

            noteRepositoryMock.Setup(x => x.ReadAll(1)).Returns(new List<CustomerNote>() { note, secondNote });

            var controller = new NotesController(customerRepositoryMock.Object, noteRepositoryMock.Object);

            var notes = controller.GetAll(1);
            Assert.NotNull(notes);

            //Assert.Equal(note, notes[0]);
            //Assert.Equal(secondNote, notes[1]);
        }

        [Fact]
        public void ShouldThrowExceptionIfThereIsNoNotes()
        {
            var noteRepositoryMock = new Mock<IEntityRepository<CustomerNote>>();
            var customerRepositoryMock = new Mock<IEntityRepository<Customer>>();
            noteRepositoryMock.Setup(x => x.ReadAll(1)).Returns(new List<CustomerNote>());

            var controller = new NotesController(customerRepositoryMock.Object, noteRepositoryMock.Object);

            Assert.Throws<NotFoundException>(() => controller.GetAll(1));
        }

        [Fact]
        public void ShouldThrowExceptionIfThereIsNoNote()
        {
            var noteRepositoryMock = new Mock<IEntityRepository<CustomerNote>>();
            var customerRepositoryMock = new Mock<IEntityRepository<Customer>>();
            noteRepositoryMock.Setup(x => x.Read(1)).Returns((CustomerNote)null);

            var controller = new NotesController(customerRepositoryMock.Object, noteRepositoryMock.Object);

            Assert.Throws<NotFoundException>(() => controller.Get(1));
        }

        [Fact]
        public void ShouldThrowExceptionIfNoteIsNotCreated()
        {
            var noteRepositoryMock = new Mock<IEntityRepository<CustomerNote>>();
            var customerRepositoryMock = new Mock<IEntityRepository<Customer>>();

            var note = new CustomerNote()
            {
                CustomerId = 1
            };

            customerRepositoryMock.Setup(x => x.Read(1)).Returns(new Customer());
            noteRepositoryMock.Setup(x => x.Create(note)).Returns(0);

            var controller = new NotesController(customerRepositoryMock.Object, noteRepositoryMock.Object);

            Assert.Throws<Exception>(() => controller.Post(note));
        }

        [Fact]
        public void ShouldThrowExceptionIfThereIsNoCustomerWithGivenId()
        {
            var noteRepositoryMock = new Mock<IEntityRepository<CustomerNote>>();
            var customerRepositoryMock = new Mock<IEntityRepository<Customer>>();

            var note = new CustomerNote()
            {
                CustomerId = 1
            };

            customerRepositoryMock.Setup(x => x.Read(1)).Returns((Customer)null);
            noteRepositoryMock.Setup(x => x.Create(note)).Returns(1);

            var controller = new NotesController(customerRepositoryMock.Object, noteRepositoryMock.Object);

            Assert.Throws<NotFoundException>(() => controller.Post(note));
        }

        [Fact]
        public void ShouldThrowExceptionIfThereIsNoNoteToUpdate()
        {
            var noteRepositoryMock = new Mock<IEntityRepository<CustomerNote>>();
            var customerRepositoryMock = new Mock<IEntityRepository<Customer>>();

            var note = new CustomerNote()
            {
                CustomerId = 1
            };

            noteRepositoryMock.Setup(x => x.Read(1)).Returns((CustomerNote)null);

            var controller = new NotesController(customerRepositoryMock.Object, noteRepositoryMock.Object);

            Assert.Throws<NotFoundException>(() => controller.Put(1, note));
        }

        [Fact]
        public void ShouldThrowExceptionIfThereIsNoNoteToDelete()
        {
            var noteRepositoryMock = new Mock<IEntityRepository<CustomerNote>>();
            var customerRepositoryMock = new Mock<IEntityRepository<Customer>>();

            var note = new CustomerNote()
            {
                CustomerId = 1
            };

            noteRepositoryMock.Setup(x => x.Read(1)).Returns((CustomerNote)null);

            var controller = new NotesController(customerRepositoryMock.Object, noteRepositoryMock.Object);

            Assert.Throws<NotFoundException>(() => controller.Delete(1));
        }

        [Fact]
        public void ShouldBeAbleToCreateNote()
        {
            var noteRepositoryMock = new Mock<IEntityRepository<CustomerNote>>();
            var customerRepositoryMock = new Mock<IEntityRepository<Customer>>();

            var fixture = new EFCustomerRepositoryFixture();
            var customer = fixture.MockCustomer();

            var note = new CustomerNote()
            {
                CustomerId = 1,
                Note = "Kitty Ipsum"
            };   

            noteRepositoryMock.Setup(x => x.Create(note)).Returns(1);
            noteRepositoryMock.Setup(x => x.Read(1)).Returns(note);
            customerRepositoryMock.Setup(x => x.Read(1)).Returns(customer);

            var controller = new NotesController(customerRepositoryMock.Object, noteRepositoryMock.Object);
            controller.Post(note);
            var fetchedNote = controller.Get(1);

            noteRepositoryMock.Verify(x => x.Create(note), Times.Exactly(1));
            //Assert.Equal(note, fetchedNote);
        }

        [Fact]
        public void ShouldBeAbleToUpdateNote()
        {
            var noteRepositoryMock = new Mock<IEntityRepository<CustomerNote>>();
            var customerRepositoryMock = new Mock<IEntityRepository<Customer>>();

            var fixture = new EFCustomerRepositoryFixture();
            var customer = fixture.MockCustomer();

            var note = new CustomerNote()
            {
                CustomerId = 1,
                Note = "Kitty Ipsum"
            };

            noteRepositoryMock.Setup(x => x.Read(1)).Returns(note);
            noteRepositoryMock.Setup(x => x.Update(note));
            
            var controller = new NotesController(customerRepositoryMock.Object, noteRepositoryMock.Object);
            controller.Put(1, note);

            var fetchedNote = controller.Get(1);

            noteRepositoryMock.Verify(x => x.Update(note), Times.Exactly(1));
            //Assert.Equal(note, fetchedNote);
        }

        [Fact]
        public void ShouldBeAbleToDeleteNote()
        {
            var noteRepositoryMock = new Mock<IEntityRepository<CustomerNote>>();
            var customerRepositoryMock = new Mock<IEntityRepository<Customer>>();

            var fixture = new EFCustomerRepositoryFixture();
            var customer = fixture.MockCustomer();

            var note = new CustomerNote()
            {
                CustomerId = 1,
                Note = "Kitty Ipsum"
            };

            noteRepositoryMock.Setup(x => x.Read(1)).Returns(note);
            noteRepositoryMock.Setup(x => x.Delete(1));

            var controller = new NotesController(customerRepositoryMock.Object, noteRepositoryMock.Object);
            controller.Delete(1);

            noteRepositoryMock.Verify(x => x.Delete(1), Times.Exactly(1));
        }
    }
}
