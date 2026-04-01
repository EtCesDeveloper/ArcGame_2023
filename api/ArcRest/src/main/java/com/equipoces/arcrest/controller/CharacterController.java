package com.equipoces.arcrest.controller;

import com.equipoces.arcrest.model.Character;
import com.equipoces.arcrest.service.CharacterService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping("/api/characters")
public class CharacterController {
    @Autowired
    private CharacterService characterService;

    @GetMapping
    public List<Character> getAll() {
        return characterService.getAllCharacters();
    }

    @GetMapping("/{id}")
    public Optional<Character> findCharacterById(@PathVariable("id") int id) {
        return characterService.getCharacterById(id);
    }

    @PostMapping("/create")
    public Character createCharacter(@RequestBody Character character) {
        return characterService.createCharacter(character);
    }
}
