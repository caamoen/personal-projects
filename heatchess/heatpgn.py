import os 

import chess
import chess.svg
import chess.pgn

import time

from cairosvg import svg2png 

if __name__ == "__main__":
    board = chess.Board()
    move_file = open("/home/carson/Documents/Scripts/heatchess/current_move", "r")
    current_move_array = move_file.read().split(".")
    move_file.close()
    use_game = int(current_move_array[0])
    use_move = int(current_move_array[1])
    pgn_file = open("/home/carson/Documents/Scripts/heatchess/pgn_folder/pgn_" + str(use_game) + ".pgn","r")
    use_pgn = chess.pgn.read_game(pgn_file)

    n = 1
    time.sleep(5)
    while True:
        for move in use_pgn.mainline_moves():
            if n < use_move:
                board.push(move)
                n += 1
            else:
                n += 1
                use_move += 1
                board.push(move)
                svg2png(chess.svg.board(board).encode("UTF-8"),write_to='/home/carson/Documents/Scripts/heatchess/chesswallpaper.png',output_width=1600,output_height=900)
                os.system("/usr/bin/gsettings set org.gnome.desktop.background picture-uri /home/carson/Documents/Scripts/heatchess/chesswallpaper.png")
                move_file = open("/home/carson/Documents/Scripts/heatchess/current_move", "w")
                move_file.write(str(use_game) + "." + str(use_move))
                move_file.close()
                time.sleep(5)
        time.sleep(10)
        board = chess.Board()
        pgn_total = len(os.listdir("/home/carson/Documents/Scripts/heatchess/pgn_folder"))
        use_game += 1
        use_move = 1
        n = 1 
        if use_game > pgn_total:
            use_game = 1
        pgn_file = open("/home/carson/Documents/Scripts/heatchess/pgn_folder/pgn_" + str(use_game) + ".pgn","r")
        use_pgn = chess.pgn.read_game(pgn_file)
        svg2png(chess.svg.board(board).encode("UTF-8"),write_to='/home/carson/Documents/Scripts/heatchess/chesswallpaper.png',output_width=1600,output_height=900)
        os.system("/usr/bin/gsettings set org.gnome.desktop.background picture-uri /home/carson/Documents/Scripts/heatchess/chesswallpaper.png")
        move_file = open("/home/carson/Documents/Scripts/heatchess/current_move", "w")
        move_file.write(str(use_game) + "." + str(use_move))
        time.sleep(5)