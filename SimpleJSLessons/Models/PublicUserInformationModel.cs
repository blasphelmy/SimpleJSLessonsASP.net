using Microsoft.EntityFrameworkCore;
using SimpleJSLessons.data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SimpleJSLessons.Models
{
    public class PublicUserInformationModel
    {
        public SimpleJSLessonsDbContext databaseContext;
        public string username { get; set; }
        public DateTime dateJoined { get; set; }
        private ApiUser thisUser { get; set; }
        public ICollection<DataDataTable> AuthoredDemoed { get; set; }
        public PublicUserInformationModel(SimpleJSLessonsDbContext context, string username)
        {
            databaseContext = context;
            try
            {
                thisUser = databaseContext.ApiUser.FromSqlRaw($@"use SimpleJSLessonsAPIData
                                                                select * from apiUser
                                                                where username = '{username}'").ToList()[0];
            }
            catch
            {
                System.Console.WriteLine("Error finding user..");
            }
            if(thisUser != null)
            {
                this.username = username;
                dateJoined = thisUser.DateCreated;
                AuthoredDemoed = context.DataDataTable.FromSqlRaw($@"select dataDataTable.Id, dataDataTable.imageData, dataDataTable.dataHash,
                                                                    dataDataTable.uploadedBy, dataDataTable.title, 
                                                                    dataDataTable.isPublic, dataDataTable.uploadDate
                                                                    from dataDataTable
                                                                    inner join UserSavedDemos 
                                                                    on dataDataTable.dataHash = UserSavedDemos.demoHash
                                                                    where uploadedBy = '{username}'
                                                                    and isPublic = 0").ToList();
            }
        }
        public ICollection<LikesTable> getUserLikes()
        {
            return thisUser.LikesTable.ToList();
        }

    }
}
