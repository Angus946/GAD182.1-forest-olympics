using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aize
{
    public class Sequencer : MonoBehaviour
    {
        public List<GameObject> blocks = new List<GameObject>();
        public List<GameObject> blockSequence = new List<GameObject>(3);

        GameObject activeBlock;
        int newBlock;
        Vector2 blockPosition;

        bool canBreak = false;
        int score = 0;

        float gameTimer = 20;
        bool gameTimerActive = false;

        float startTimer = 3;
        bool startTimerActive = true;

        // Start is called before the first frame update
        void Start()
        {
            LoadNewBlock();
            activateBlock();
            foreach (var block in blocks)
            {
                if (block.GetComponent<Block>() == null)
                {
                    Debug.Log("not a valid block");
                    blocks.Remove(block);
                }
            }

        }

        // Update is called once per frame
        void Update()
        {
            if (startTimerActive)
            {
                startTimer -= Time.deltaTime;

                if (startTimer < 0)
                {
                    startTimerActive = false;
                    startTimer = 0;
                    Debug.Log("gamestart");
                    gameTimerActive = true;
                    canBreak = true;
                }
            }

            if (gameTimerActive)
            {
                gameTimer -= Time.deltaTime;

                if (gameTimer < 0)
                {
                    canBreak = false;
                    gameTimerActive = false;
                    gameTimer = 0;
                    Debug.Log("Game over! You got a score of " + score);
                }
            }

            if (canBreak)
            {
                if (Input.GetKeyDown(activeBlock.GetComponent<Block>().breakKey))
                {
                    breakBlock(activeBlock);

                }
            }
        }

        void LoadNewBlock()
        {
            while (blockSequence.Count < blockSequence.Capacity)
            {

                newBlock = UnityEngine.Random.Range(0, blocks.Count);
                GameObject blockCopy = Instantiate(blocks[newBlock]);
                blockSequence.Add(blockCopy);
            }
        }

        void activateBlock()
        {
            activeBlock = blockSequence[0];

            foreach (var block in blockSequence)
            {

                block.transform.position = blockPosition;
                blockPosition.x += 3;
                block.GetComponent<SpriteRenderer>().sortingLayerName = blockSequence.IndexOf(block).ToString();
            }

            blockPosition = new Vector2(0, 0);
        }

        void breakBlock(GameObject block)
        {
            score++;
            blockSequence.Remove(block);
            LoadNewBlock();
            activateBlock();
            Destroy(block);
        }
    }
}