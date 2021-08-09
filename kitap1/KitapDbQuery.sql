Select
    tbl_YayinEvleri.YayinEviAdi,
    tbl_Yazarlar.AdiSoyadi,
    tbl_Uyeler.AdSoyad,
    tbl_KitapListesi.EmanetDurumu,
    tbl_KitapListesi.KitapAdi,
    tbl_KitapListesi.Resim,
    tbl_KitapListesi.SayfaSayisi,
    tbl_KitapListesi.TeminTarihi,
    tbl_KitapListesi.TeminTuru,
    tbl_KitapListesi.BaskiTarihi,
    tbl_KitapListesi.BaskiSayisi,
    tbl_KitapListesi.BaskiYeri,
    tbl_KitapListesi.KitapKonusu,
    tbl_KitapListesi.KitapTuru,
    tbl_KitapListesi.Barkod,
    tbl_KitapListesi.ID,
    tbl_Uyeler.ID As ID1
From
    tbl_KitapListesi Inner Join
    tbl_YayinEvleri On tbl_KitapListesi.YayınEviID = tbl_YayinEvleri.ID Inner Join
    tbl_Yazarlar On tbl_KitapListesi.YazarAdiID = tbl_Yazarlar.ID Inner Join
    tbl_Uyeler On tbl_KitapListesi.EkleyenID = tbl_Uyeler.ID