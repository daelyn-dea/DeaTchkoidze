﻿namespace PizzaProject.Application.RankHistories
{
    public class RankHistoryResponseModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PizzaId { get; set; }
        public decimal? Rank { get; set; }
        public string Pizza { get; set; }
    }
}
