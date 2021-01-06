use TaiWei
SELECT * FROM M_CELL_PART_RAW

SELECT cpositioncode,cposition,count(distinct cinvcode) PART_CNT 
FROM M_CELL_PART_RAW
GROUP BY cpositioncode,cposition


SELECT cinvcode,PART,RANK,RANK_FINAL,count(distinct cpositioncode) CELL_CNT 
FROM M_CELL_PART_RAW
GROUP BY cinvcode,PART,RANK,RANK_FINAL