SELECT cpositioncode,cposition,COUNT(*) cnt FROM STOCK_CURRENT 
WHERE cwarehouse IN ('030��','̨Ω30��') AND cpositioncode !='TW001'
GROUP BY cpositioncode,cposition
ORDER BY cpositioncode,cposition




SELECT DISTINCT cstatus FROM STOCK_CURRENT

