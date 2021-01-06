SELECT id,cpositioncode,cposition,cinvcode,SUBSTRING(cinvcode,0,LEN(cinvcode)-1) PART,
    SUBSTRING(cinvcode,LEN(cinvcode),1) RANK, 
IIF(SUBSTRING(cinvcode,LEN(cinvcode),1) = '_', ' ' , SUBSTRING(cinvcode,LEN(cinvcode),1) ) RANK_FINAL, 

cinvname,
iqty FROM STOCK_CURRENT 
WHERE cwarehouse IN ('030Žì','Ì¨Î©30Žì') AND cpositioncode !='TW001' 