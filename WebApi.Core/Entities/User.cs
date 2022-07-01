using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebApi.Core.Entities
{
    public class User
    {
        public int ID { get; set; }

        public DateTime CreateDate { get; set; }

        //[ForeignKey(nameof(CreatedByUser))]
        public int CreatedBy { get; set; }

        public DateTime ModifyDate { get; set; }

        //[ForeignKey(nameof(ModifiedByUser))]
        public int ModifiedBy { get; set; }

        public bool IsDeleted { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string ProfilePicture { get; set; }


        public User CreatedByUser { get; set; }
        public User ModifiedByUser { get; set; }
        public ICollection<User> CreatedUsers { get; set; }
        public ICollection<User> ModifiedUsers { get; set; }
        public ICollection<ActionType> CreatedActionTypes { get; set; }
        public ICollection<ActionType> ModifiedActionTypes { get; set; }

        public ICollection<MaintenanceHistory> CreatedMaintenanceHistories { get; set; }
        public ICollection<MaintenanceHistory> ModifiedMaintenanceHistories { get; set; }

        public ICollection<PictureGroup> CreatedPictureGroups { get; set; }
        public ICollection<PictureGroup> ModifiedPictureGroups { get; set; }

        public ICollection<Status> CreatedStatuses { get; set; }
        public ICollection<Status> ModifiedStatuses { get; set; }

        public ICollection<Maintenance> CreatedMaintenances { get; set; }
        public ICollection<Maintenance> ModifiedMaintenances { get; set; }

        public ICollection<Maintenance> Maintenances { get; set; }
        public ICollection<Maintenance> ResponsibleMaintenances { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }
        public ICollection<Vehicle> CreatedVehicles { get; set; }
        public ICollection<Vehicle> ModifiedVehicles { get; set; }

        public ICollection<VehicleType> CreatedVehicleTypes { get; set; }
        public ICollection<VehicleType> ModifiedVehicleTypes { get; set; }

        public UserAuthentication UserAuthentication { get; set; }
    }
}
