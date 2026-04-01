package com.equipoces.arcrest.service;

import com.equipoces.arcrest.model.Character;
import com.equipoces.arcrest.repository.CharacterRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class CharacterServiceImplementation implements CharacterService {
    @Autowired
    private CharacterRepository characterRepository;

    @Override
    public List<Character> getAllCharacters() {
        return (List<Character>) characterRepository.findAll();
    }

    @Override
    public Optional<Character> getCharacterById(int id) {
        return characterRepository.findById(id);
    }

    @Override
    public Character createCharacter(Character character) {
        return characterRepository.save(character);
    }
}
