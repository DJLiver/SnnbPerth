﻿using System;
using System.Collections.Generic;

using ExceptionLog;

namespace SnnbDB.Models;

public partial class MSpectralNetGroup
{
    private void UpdateSelf(SnnbCommPack snnbCommPack)
    {
        try
        {
            DateStamp = DateTime.Now;
            GroupId = snnbCommPack.SpectralNetGroup.GroupId;
            GroupName = snnbCommPack.SpectralNetGroup.GroupName;
            Site = snnbCommPack.SpectralNetGroup.Site;
            UnitId = snnbCommPack.SpectralNetGroup.UnitId;
            UnitName = snnbCommPack.SpectralNetGroup.UnitName;
            ChassisName = snnbCommPack.SpectralNetGroup.ChassisName;
            Location = snnbCommPack.SpectralNetGroup.Location;
            IpAddress = snnbCommPack.SpectralNetGroup.IpAddress;
            Direction = snnbCommPack.SpectralNetGroup.Direction;
            DisplayOrder = snnbCommPack.SpectralNetGroup.DisplayOrder;
            Error = snnbCommPack.Error;
            ErrorText = snnbCommPack.ErrorText;
            ReponseTime = 100;

        }
        catch (Exception)
        {
            throw;
        }
    }
public void SaveRestToDB(SnnbCommPack snnbCommPack)
    {
        using SnnbFoContext c = new SnnbFoContext();

        try
        {
            List<MSpectralNetGroup>? v = (from f in c.MSpectralNetGroups
                                where f.UnitId == snnbCommPack.SpectralNetGroup.UnitId
                                select f).ToList();
            MSpectralNetGroup rm;
            switch (v.Count)
            {
                case 0:
                    this.UpdateSelf(snnbCommPack);
                    c.MSpectralNetGroups.Add(this);
                    break;
                case 1:
                    rm = v[0];
                    rm.UpdateSelf(snnbCommPack);
                    break;
                default:
                    for (int i = 1; i < v.Count; i++)
                    {
                        rm = v[i];
                        c.MSpectralNetGroups.Remove(rm);
                    }
                    rm = v[0];
                    rm.UpdateSelf(snnbCommPack);
                    break;
            }

            c.SaveChanges();
        }
        catch (Exception ex)
        {
            ExLog.Log(ex);
            return;
        }
    }

}
