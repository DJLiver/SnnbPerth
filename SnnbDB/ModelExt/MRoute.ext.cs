﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Extensions;

using ExceptionLog;

using SnnbDB.Rest;

namespace SnnbDB.Models;
public partial class MRoute
{
    #region Ctor
    public MRoute()
    {

    }
    #endregion

    private void UpdateSelf(NetworkRoute structure)
    {
        //List<ArrayRfOutputStream> restMain = snnbCommPack.RestMain.rfOutputStream.array.ToList();
        ///* Excel lines below */
        this.Destination = structure.destination.value.Truncate(128);
        this.Gateway = structure.gateway.value.Truncate(128);
        this.Netmask = structure.netmask.value;
    }


    public void SaveRestToDB(SnnbCommPack snnbCommPack)
    {
        this.UnitId = snnbCommPack.SpectralNetGroup.UnitId;

        List<ArrayNR>? nr = snnbCommPack.RestMain.routes.array.ToList();


        foreach (var item in nr)
        {
            SaveRestToDB(item.structure, snnbCommPack);
        }
    }

    private void SaveRestToDB(NetworkRoute structure, SnnbCommPack snnbCommPack)
    {
        using SnnbFoContext c = new SnnbFoContext();

        try
        {
            // Unique by       ,[sourceIpAddress]      ,[sourcePort]      ,[streamId]

            List<MRoute>? v = (from f in c.MRoutes
                               where f.UnitId == snnbCommPack.SpectralNetGroup.UnitId &
                               f.Destination == structure.destination.value &
                               f.Netmask == structure.netmask.value
                               select f).ToList();
            MRoute rm;
            switch (v.Count)
            {
                case 0:
                    this.UpdateSelf(structure);
                    c.MRoutes.Add(this);
                    break;
                case 1:
                    rm = v[0];
                    rm.UpdateSelf(structure);
                    break;
                default:
                    for (int i = 1; i < v.Count; i++)
                    {
                        rm = v[i];
                        c.MRoutes.Remove(rm);
                    }
                    rm = v[0];
                    rm.UpdateSelf(structure);
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
