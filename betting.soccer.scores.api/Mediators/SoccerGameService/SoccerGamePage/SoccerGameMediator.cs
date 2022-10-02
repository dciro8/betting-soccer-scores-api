﻿using betting.soccer.scores.api.Domains.SoccerGameService.SoccerGamePage;
using betting.soccer.scores.api.Infraestructure;
using Microsoft.EntityFrameworkCore;

namespace betting.soccer.scores.api.Mediators.SoccerGameService.SoccerGamePage
{
    public class SoccerGameMediator: IRegisterSoccerGame, ISoccerGame
    {
        private readonly DataContext _context;

        public SoccerGameMediator(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<int> RemoveSoccerGameAsync(SoccerGame soccerGame)
        {
            _context.SoccerGames.Remove(soccerGame);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> UpdateAsync(SoccerGame soccerGame)
        {
            _context.SoccerGames.Update(soccerGame);
            return await _context.SaveChangesAsync();
        }
        public async Task<SoccerGame> GetByIdSoccerGameAsync(Guid id)
        {
            return await _context.SoccerGames.FindAsync(id);
        }
        public async Task<int> RegisterSoccerGameAsync(SoccerGame soccerGame)
        {
            await _context.SoccerGames.AddAsync(soccerGame);
            return await _context.SaveChangesAsync();
        }
        public async Task<IList<SoccerGame>> GetAllSoccerGameAsync()
        {
            return await _context.SoccerGames.ToListAsync();
        }
    }
}
