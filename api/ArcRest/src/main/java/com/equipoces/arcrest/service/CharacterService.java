package com.equipoces.arcrest.service;

import com.equipoces.arcrest.model.Character;

import java.util.List;
import java.util.Optional;

public interface CharacterService {
    /**
     * Get all characters
     *
     * @return All characters
     */
    List<Character> getAllCharacters();

    /**
     * Get character by ID
     *
     * @param id Character id
     * @return Character if found, null if not
     */
    Optional<Character> getCharacterById(int id);

    /**
     * Creates a character
     * @param character The character to create
     * @return Created character
     */
    Character createCharacter(Character character);
}
