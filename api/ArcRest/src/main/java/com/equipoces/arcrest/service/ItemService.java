package com.equipoces.arcrest.service;

import com.equipoces.arcrest.model.Item;

import java.util.List;
import java.util.Optional;

public interface ItemService {
    /**
     * Get all items
     *
     * @return All items
     */
    List<Item> getAllItems();

    /**
     * Get item by ID
     *
     * @param id Item id
     * @return Item if found, null if not
     */
    Optional<Item> getItemById(int id);

    /**
     * Creates an item
     *
     * @param character The item to create
     * @return Created item
     */
    Item createItem(Item character);
}
