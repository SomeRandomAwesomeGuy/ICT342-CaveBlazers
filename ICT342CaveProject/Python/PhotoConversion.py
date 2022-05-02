import numpy as np
from PIL import Image
from equilib import equi2equi
from equilib import cube2equi

"""
 @software{pyequilib2021github,
  author = {Haruya Ishikawa},
  title = {PyEquilib: Processing Equirectangular Images with Python},
  url = {http://github.com/haruishi43/equilib},
  version = {0.5.0},
  year = {2021},
 }
"""


class PhotoConversion:
    # Toolbox for converting images between equirectangular and panoramic modes

    @staticmethod
    def load_image(image):
        target_image = Image.open(image)
        target_image = np.asarray(target_image)
        target_image = np.transpose(target_image, (2, 0, 1))
        return target_image

    @staticmethod
    def save_image(image, path):
        image.save(path)

    @staticmethod
    def equirectangular_to_equirectangular(image):
        # Converts between equirectangualar
        return equi2equi(cubemap=image,
                         height=30735,
                         width=3072)

    @staticmethod
    def cubemap_to_equirectangular(image):
        # Converts the cubemap into an equirectangular
        return cube2equi(cubemap=image,
                         height=30735,
                         width=3072)

    @staticmethod
    def crop_equirectangular(image):
        # Crops image in line
        width, height = image.size

        image = image.crop((0, (height/2)+(width/10) , width , (height/2)-(width/10)))

        return image
        # Crop equirectangular Images to the correct dimensions

    @staticmethod
    def crop_rectilinear(image):
        width, height = image.size
        ratio = height/width

        return image


"""
Complete Panoramics
Step 1, Convert to equirectangular
Step 2, Crop to 10:1 aspect ratio
Step 3, Upscale image

"""


converter = PhotoConversion()
converter.crop_equirectangular()

