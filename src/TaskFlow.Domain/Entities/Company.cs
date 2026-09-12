using TaskFlow.Domain.Common;

namespace TaskFlow.Domain.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; private set; }

        public string? TaxNumber { get; private set; }

        public string? TaxOffice { get; private set; }

        public string? PhoneNumber { get; private set; }

        public string? Sector { get; private set; }

        public string? Address { get; private set; }

        public bool IsActive { get; private set; } = true;


        public Company(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Company name cannot be null or empty.", nameof(name));
            }
            Name = name.Trim();
        }

        public void ChangeName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
            {
                throw new ArgumentException("Company name cannot be null or empty.",
                    nameof(newName));
            }
            Name = newName.Trim();
            UpdatedAtUtc = DateTime.UtcNow;

        }

        public void Deactivate()
        {
            if (IsActive)
            {
                IsActive = false;
                UpdatedAtUtc = DateTime.UtcNow;
            }
        }

        public void Activate()
        {
            if (!IsActive)
            {
                IsActive = true;
                UpdatedAtUtc = DateTime.UtcNow;
            }
        }
        public void UpdateDetails(string? taxNumber, string? taxOffice, string? phoneNumber, string? sector, string? address)
        {
            TaxNumber = taxNumber;
            PhoneNumber = phoneNumber;
            Sector = sector;
            Address = address;
            TaxOffice = taxOffice;
            UpdatedAtUtc = DateTime.UtcNow;

        }

    }
}
