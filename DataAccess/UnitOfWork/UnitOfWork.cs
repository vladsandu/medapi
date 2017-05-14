using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.IO;
using DataAccess.Entities;
using DataAccess.Entities.Character;
using DataAccess.Repository;
using DataAccess.Entities.Contact;
using DataAccess.Entities.Examination;
using DataAccess.Entities.Staff;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        #region Private member variables...

        private readonly MedContext _context;
        private GenericRepository<Person> _personRepository;
        private GenericRepository<InsuranceStatus> _insuranceStatusRepository;
        private GenericRepository<Nationality> _nationalityRepository;
        private GenericRepository<Patient> _patientRepository;

        private GenericRepository<City> _cityRepository;
        private GenericRepository<Country> _countryRepository;
        private GenericRepository<ContactDetails> _contactDetailsRepository;

        private GenericRepository<Examination> _examinationRepository;
        private GenericRepository<Staff> _staffRepository;
        private GenericRepository<Physician> _physicianRepository;
        private GenericRepository<ExaminationType> _examinationTypeRepository;
        #endregion

        public UnitOfWork()
        {
            _context = new MedContext();
        }

        #region Public Repository Creation properties...

        /// <summary>
        ///     Get/Set Property for product repository.
        /// </summary>
        public GenericRepository<Person> PersonRepository
        {
            get
            {
                if (_personRepository == null)
                    _personRepository = new GenericRepository<Person>(_context);
                return _personRepository;
            }
        }
        public GenericRepository<Staff> StaffRepository
        {
            get
            {
                if (_staffRepository == null)
                    _staffRepository = new GenericRepository<Staff>(_context);
                return _staffRepository;
            }
        }
        public GenericRepository<Physician> PhysicianRepository
        {
            get
            {
                if (_physicianRepository == null)
                    _physicianRepository = new GenericRepository<Physician>(_context);
                return _physicianRepository;
            }
        }
        public GenericRepository<InsuranceStatus> InsuranceStatusRepository
        {
            get
            {
                if (_insuranceStatusRepository == null)
                    _insuranceStatusRepository = new GenericRepository<InsuranceStatus>(_context);
                return _insuranceStatusRepository;
            }
        }

        public GenericRepository<Nationality> NationalityRepository
        {
            get
            {
                if (_nationalityRepository == null)
                    _nationalityRepository = new GenericRepository<Nationality>(_context);
                return _nationalityRepository;
            }
        }

        public GenericRepository<Examination> ExaminationRepository
        {
            get
            {
                if (_examinationRepository == null)
                    _examinationRepository = new GenericRepository<Examination>(_context);
                return _examinationRepository;
            }
        }

        public GenericRepository<ExaminationType> ExaminationTypeRepository
        {
            get
            {
                if (_examinationTypeRepository == null)
                    _examinationTypeRepository = new GenericRepository<ExaminationType>(_context);
                return _examinationTypeRepository;
            }
        }

        public GenericRepository<Patient> PatientRepository
        {
            get
            {
                if (_patientRepository == null)
                    _patientRepository = new GenericRepository<Patient>(_context);
                return _patientRepository;
            }
        }
        public GenericRepository<City> CityRepository
        {
            get
            {
                if (_cityRepository == null)
                    _cityRepository = new GenericRepository<City>(_context);
                return _cityRepository;
            }
        }

        public GenericRepository<Country> CountryRepository
        {
            get
            {
                if (_countryRepository == null)
                    _countryRepository = new GenericRepository<Country>(_context);
                return _countryRepository;
            }
        }

        public GenericRepository<ContactDetails> ContactDetailsRepository
        {
            get
            {
                if (_contactDetailsRepository == null)
                    _contactDetailsRepository = new GenericRepository<ContactDetails>(_context);
                return _contactDetailsRepository;
            }
        }
        #endregion

        #region Public member methods...

        /// <summary>
        ///     Save method.
        /// </summary>
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(
                        string.Format(
                            "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:",
                            DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName,
                            ve.ErrorMessage));
                    }
                }
                File.AppendAllLines(@"C:\errors.txt", outputLines);

                throw e;
            }
        }

        #endregion

        #region Implementing IDiosposable...

        #region private dispose variable declaration...

        private bool disposed;

        #endregion

        /// <summary>
        ///     Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///     Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        #endregion
    }
}